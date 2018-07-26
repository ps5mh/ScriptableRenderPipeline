using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.Experimental.Rendering.HDPipeline
{
    internal unsafe static class HDUnsafeUtils
    {
        public static void CombineHashes(int count, Hash128* hashes, Hash128* outHash)
        {
            for (int i = 0; i < count; ++i)
                HashUtilities.AppendHash(ref hashes[i], ref *outHash);
        }

        public static void CombineHashes(IList<Hash128> hashes, Hash128* outHash)
        {
            for (int i = 0; i < hashes.Count; ++i)
            {
                var h = hashes[i];
                HashUtilities.AppendHash(ref h, ref *outHash);
            }
        }

        /// <summary>
        /// Compare hashes of two collections and provide
        /// a list of indices <paramref name="removeIndices"/> to remove in <paramref name="oldHashes"/>
        /// and a list of indices <paramref name="addIndices"/> to add in <paramref name="newHashes"/>.
        ///
        /// Assumes that <paramref name="newHashes"/> and <paramref name="oldHashes"/> are sorted.
        /// </summary>
        /// <param name="oldHashCount"></param>
        /// <param name="oldHashes"></param>
        /// <param name="newHashCount"></param>
        /// <param name="newHashes"></param>
        /// <param name="addIndices"></param>
        /// <param name="removeIndices"></param>
        /// <param name="addCount"></param>
        /// <param name="remCount"></param>
        /// <returns></returns>
        public static int CompareHashes(
            int oldHashCount, Hash128* oldHashes,
            int newHashCount, Hash128* newHashes,
            // assume that the capacity of indices is >= max(oldHashCount, newHashCount)
            int* addIndices, int* removeIndices,
            out int addCount, out int remCount
        )
        {
            addCount = 0;
            remCount = 0;
            // Check combined hashes
            if (oldHashCount == newHashCount)
            {
                var oldHash = new Hash128();
                var newHash = new Hash128();
                CombineHashes(oldHashCount, oldHashes, &oldHash);
                CombineHashes(newHashCount, newHashes, &newHash);
                if (oldHash == newHash)
                    return 0;
            }

            var numOperations = 0;

            var oldI = 0;
            var newI = 0;

            while (oldI < oldHashCount || newI < newHashCount)
            {
                // At the end of old array.
                if (oldI == oldHashCount)
                {
                    // No more hashes in old array. Add remaining entries from new array.
                    for (; newI < newHashCount; ++newI)
                    {
                        addIndices[addCount++] = newI;
                        ++numOperations;
                    }
                    continue;
                }

                // At end of new array.
                if (newI == newHashCount)
                {
                    // No more hashes in old array. Remove remaining entries from old array.
                    for (; oldI < oldHashCount; ++oldI)
                    {
                        removeIndices[remCount++] = oldI;
                        ++numOperations;
                    }
                    continue;
                }

                // Both arrays have data.
                if (newHashes[newI] == oldHashes[oldI])
                {
                    // Matching hash, skip.
                    ++newI;
                    ++oldI;
                    continue;
                }

                // Both arrays have data, but hashes do not match.
                if (newHashes[newI] < oldHashes[oldI])
                {
                    // oldIter is the greater hash. Push "add" jobs from the new array until reaching the oldIter hash.
                    while (newI < newHashCount && newHashes[newI] < oldHashes[oldI])
                    {
                        addIndices[addCount++] = newI;
                        ++newI;
                        ++numOperations;
                    }
                }
                else
                {
                    // newIter is the greater hash. Push "remove" jobs from the old array until reaching the newIter hash.
                    while (oldI < oldHashCount && oldHashes[oldI] < newHashes[newI])
                    {
                        removeIndices[remCount++] = oldI;
                        ++numOperations;
                    }
                }
            }

            return numOperations;
        }

        /// <summary>
        /// Remove and resize all the item in <paramref name="array"/> at indices <paramref name="indices"/>.
        /// <paramref name="indices"/> are expected to be sorted in increasing order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="count"></param>
        /// <param name="indices"></param>
        public static void RemoveSortedIndicesInArray<T>(ref T[] array, int count, int* indices)
        {
            if (count > array.Length)
                throw new ArgumentException();

            var lastItemIndex = array.Length - 1;
            for (int i = count - 1; i >= 0; --i)
            {
                var index = indices[i];
                // Swap back to delete
                array[index] = array[lastItemIndex];
                --lastItemIndex;
            }

            Array.Resize(ref array, lastItemIndex + 1);
        }

        /// <summary>
        /// Copy into <paramref name="dest"/> the values from <paramref name="src"/> designated by the indices <paramref name="indices"/>.
        /// </summary>
        /// <param name="count">Number of indices</param>
        /// <param name="indices"></param>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="stride">stride of one element in bytes.</param>
        public static void CopyToIndirect(int count, int* indices, byte* src, byte* dest, int stride)
        {
            for (int i = 0; i < count; ++i)
            {
                var srcAddress = src + stride * indices[i];
                var destAddress = dest + stride * i;
                UnsafeUtility.MemCpy(destAddress, srcAddress, stride);
            }
        }
    }
}
