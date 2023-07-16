using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashLib
{
    /// <summary>
    /// A hash to string dictionary.
    /// </summary>
    public class HashDictionary
    {
        /// <summary>
        /// The prime for computing 32-bit hashes.
        /// </summary>
        public const uint PRIME = 37;

        /// <summary>
        /// The prime for computing 64-bit hashes.
        /// </summary>
        public const ulong PRIME64 = 0x85ul;

        /// <summary>
        /// The internal dictionary.
        /// </summary>
        private readonly Dictionary<ulong, string> _hashes = new Dictionary<ulong, string>();

        /// <summary>
        /// Get the internal hashes dictionary as a new dictionary.
        /// </summary>
        public Dictionary<ulong, string> Hashes => new Dictionary<ulong, string>(_hashes);

        /// <summary>
        /// The strings to replace with other strings within provided strings.
        /// </summary>
        public Dictionary<string, string> Replacements = new Dictionary<string, string>();

        /// <summary>
        /// Create a new, empty hash dictionary.
        /// </summary>
        public HashDictionary(){}

        /// <summary>
        /// Create a new hash dictionary with provided replacements.
        /// </summary>
        /// <param name="replacements"></param>
        public HashDictionary(Dictionary<string, string> replacements)
        {
            Replacements = replacements;
        }

        /// <summary>
        /// Compute a 32-bit or 64-bit hash from a string.
        /// </summary>
        /// <param name="str">The string to hash.</param>
        /// <param name="bit64">Whether or not the hash is 64-bit.</param>
        /// <returns>The hash as a <see cref="ulong" /></returns>
        public static ulong ComputeHash(string str, bool bit64)
        {
            string hashable = str.Trim().Replace('\\', '/').ToLowerInvariant();
            if (!hashable.StartsWith("/"))
                hashable = '/' + hashable;

            return bit64 ? hashable.Aggregate(0ul, (i, c) => i * PRIME64 + c) : hashable.Aggregate(0u, (i, c) => i * PRIME + c);
        }

        /// <summary>
        /// Get the index of the bucket this hash should go into using its modulus.
        /// </summary>
        /// <param name="hash">The hash.</param>
        /// <param name="bucketCount">The total number of buckets.</param>
        /// <returns>The bucket index this bucket should go into.</returns>
        public static int GetModulusBucketIndex(ulong hash, int bucketCount)
        {
            return (int)(hash % (ulong)bucketCount);
        }

        /// <summary>
        /// Get a bucket count ideal for most buckets having the given number of hashes.
        /// </summary>
        /// <param name="hashCount">The total number of hashes that will be stored.</param>
        /// <param name="distribution">The target number of hashes to store per bucket.</param>
        /// <param name="prime">Whether or not to make sure the final bucket count is prime.</param>
        /// <returns>A distributed bucket count.</returns>
        public static int GetDistributedBucketCount(int hashCount, int distribution, bool prime = true)
        {
            return prime ? Prime.GetNextPrime(hashCount / distribution) : hashCount / distribution;
        }

        /// <summary>
        /// Get the next prime number from the given bucket count to confirm it is prime.
        /// </summary>
        /// <param name="bucketCount">The number of buckets to increase until prime.</param>
        /// <returns>A prime bucket count.</returns>
        public static int GetPrimeBucketCount(int bucketCount)
        {
            return Prime.GetNextPrime(bucketCount);
        }

        /// <summary>
        /// Read a dictionary from strings in a text file on the provided path.
        /// </summary>
        /// <param name="path">The path to read strings from.</param>
        /// <param name="bit64">Whether or nor the hashes are 64-bit.</param>
        public void ReadDictionary(string path, bool bit64)
        {
            ReadDictionary(File.ReadAllLines(path), bit64);
        }

        /// <summary>
        /// Read a dictionary from provided strings.
        /// </summary>
        /// <param name="strs">The strings to be hashed then added.</param>
        /// <param name="bit64">Whether or not the hashes are 64-bit.</param>
        public void ReadDictionary(IEnumerable<string> strs, bool bit64)
        {
            foreach (string str in strs)
            {
                if (str.Trim() != "")
                {
                    Add(str, bit64);
                }
            }
        }

        /// <summary>
        /// Read a list of hashes to strings from the given path directly into the dictionary.
        /// </summary>
        /// <param name="path">The path to read the list from.</param>
        /// <param name="separator">The separator hashes-to-strings are split by.</param>
        public void ReadHashToStringDictionary(string path, char separator = '=')
        {
            ReadHashToStringDictionary(File.ReadAllLines(path), separator);
        }

        /// <summary>
        /// Read a list of strings to hashes from the given path directly into the dictionary.
        /// </summary>
        /// <param name="path">The path to read the list from.</param>
        /// <param name="separator">The separator strings-to-hashes are split by.</param>
        public void ReadStringToHashDictionary(string path, char separator = '=')
        {
            ReadStringToHashDictionary(File.ReadAllLines(path), separator);
        }

        /// <summary>
        /// Read a list of hashes to strings directly into the dictionary.
        /// </summary>
        /// <param name="strs">A string list containing hash-to-string strings.</param>
        /// <param name="separator">The separator hash-to-string strings are split by.</param>
        /// <exception cref="InvalidDataException">A string in the strings list could not be parsed.</exception>
        /// <exception cref="DuplicateValueException">A string already existed in the dictionary.</exception>
        /// <exception cref="HashCollisionException">A hash already existed in the dictionary.</exception>
        public void ReadHashToStringDictionary(IEnumerable<string> strs, char separator = '=')
        {
            foreach (string combinedStr in strs)
            {
                string[] splitStr = combinedStr.Split(separator);
                if (splitStr.Length != 2)
                    throw new InvalidDataException($"String '{combinedStr}' split into more than two strings while getting hash and string.");
                string str = splitStr[1];
                if (!ulong.TryParse(splitStr[0], out ulong hash))
                    throw new InvalidDataException($"Value at position of hash '{splitStr[0]}' could not be parsed as a hash.");

                if (_hashes.ContainsValue(str))
                    throw new DuplicateValueException($"String '{str}' already exists within the hash dictionary.");

                if (_hashes.ContainsKey(hash))
                    throw new HashCollisionException($"Hash '{hash}' of string '{str}' already exists within the hash dictionary.");

                _hashes.Add(hash, str);
            }
        }

        /// <summary>
        /// Read a list of strings to hashes directly into the dictionary.
        /// </summary>
        /// <param name="strs">A string list containing string-to-hash strings.</param>
        /// <param name="separator">The separator string-to-hash strings are split by.</param>
        /// <exception cref="InvalidDataException">A string in the strings list could not be parsed.</exception>
        /// <exception cref="DuplicateValueException">A string already existed in the dictionary.</exception>
        /// <exception cref="HashCollisionException">A hash already existed in the dictionary.</exception>
        public void ReadStringToHashDictionary(IEnumerable<string> strs, char separator = '=')
        {
            foreach (string combinedStr in strs)
            {
                string[] splitStr = combinedStr.Split(separator);
                if (splitStr.Length != 2)
                    throw new InvalidDataException($"String '{combinedStr}' split into more than two strings while getting hash and string.");
                string str = splitStr[0];
                if (!ulong.TryParse(splitStr[1], out ulong hash))
                    throw new InvalidDataException($"Value at position of hash '{splitStr[1]}' could not be parsed as a hash.");

                if (_hashes.ContainsValue(str))
                    throw new DuplicateValueException($"String '{str}' already exists within the hash dictionary.");

                if (_hashes.ContainsKey(hash))
                    throw new HashCollisionException($"Hash '{hash}' of string '{str}' already exists within the hash dictionary.");

                _hashes.Add(hash, str);
            }
        }

        /// <summary>
        /// Gets all of the hashes in the dictionary as a new list.
        /// </summary>
        /// <returns>A list of all the hashes in the dictionary.</returns>
        public IList<ulong> GetHashes()
        {
            return new List<ulong>(_hashes.Keys);
        }

        /// <summary>
        /// Gets all of the strings in the dictionary as a new list.
        /// </summary>
        /// <returns>A list of all the strings in the dictionary.</returns>
        public IList<string> GetStrings()
        {
            return new List<string>(_hashes.Values);
        }

        /// <summary>
        /// Get a list of hashes to strings.
        /// </summary>
        /// <param name="separator">The separator between the hash and string.</param>
        /// <returns>A list of hashes to strings.</returns>
        public IList<string> GetHashesToStrings(char separator = '=')
        {
            var strs = new List<string>();
            foreach (var hash in _hashes.Keys)
                strs.Add($"{hash}{separator}{_hashes[hash]}");
            return strs;
        }

        /// <summary>
        /// Get a list of strings to hashes.
        /// </summary>
        /// <param name="separator">The separator between the string and hash.</param>
        /// <returns>A list of strings to hashes.</returns>
        public IList<string> GetStringsToHashes(char separator = '=')
        {
            var strs = new List<string>();
            foreach (var hash in _hashes.Keys)
                strs.Add($"{_hashes[hash]}{separator}{hash}");
            return strs;
        }

        /// <summary>
        /// Write all hashes in the dictionary to a file on the given path.
        /// </summary>
        /// <param name="path">The path to write all hashes to.</param>
        public void WriteHashes(string path)
        {
            File.WriteAllLines(path, _hashes.Keys.ToStringList());
        }

        /// <summary>
        /// Write all strings in the dictionary to a file on the given path.
        /// </summary>
        /// <param name="path">The path to write all strings to.</param>
        public void WriteStrings(string path)
        {
            File.WriteAllLines(path, _hashes.Values);
        }

        /// <summary>
        /// Write all hashes to strings to a file on the given path.
        /// </summary>
        /// <param name="path">The path to write to.</param>
        /// <param name="separator">The separator between the hash and string.</param>
        public void WriteHashesToStrings(string path, char separator = '=')
        {
            File.WriteAllLines(path, GetHashesToStrings(separator));
        }

        /// <summary>
        /// Write all strings to hashes to a file on the given path.
        /// </summary>
        /// <param name="path">The path to write to.</param>
        /// <param name="separator">The separator between the string and hash.</param>
        public void WriteStringsToHashes(string path, char separator = '=')
        {
            File.WriteAllLines(path, GetStringsToHashes(separator));
        }

        /// <summary>
        /// Tries to get the string of a provided hash from the dictionary.
        /// </summary>
        /// <param name="hash">The hash to get the string for.</param>
        /// <param name="str">The found string.</param>
        /// <returns>True if the hash dictionary has the given hash, false if not.</returns>
        public bool TryGetString(ulong hash, out string? str)
        {
            return _hashes.TryGetValue(hash, out str);
        }

        /// <summary>
        /// Get a string at the provided hash.
        /// </summary>
        /// <param name="hash">The hash to get the string of.</param>
        /// <returns>The string at the provided hash in the dictionary.</returns>
        public string GetString(ulong hash)
        {
            return _hashes[hash];
        }

        /// <summary>
        /// Add a new string to the hash dictionary.
        /// </summary>
        /// <param name="str">The string to hash and add.</param>
        /// <param name="bit64">Whether or not hashes are 64-bit, or long.</param>
        /// <exception cref="DuplicateValueException">A string already existed in the dictionary.</exception>
        /// <exception cref="HashCollisionException">A hash already existed in the dictionary.</exception>
        public void Add(string str, bool bit64)
        {
            bool found;
            do
            {
                found = false;
                foreach (string k in Replacements.Keys)
                {
                    if (str.Contains(k))
                    {
                        found = true;
                        str = str.Replace(k, Replacements[k]);
                    }
                }
            }
            while (found);

            str = str.Replace('/', '\\');
            while (str.StartsWith(".\\"))
                str = str.Substring(2);

            if (_hashes.ContainsValue(str))
                throw new DuplicateValueException($"String '{str}' already exists within the hash dictionary.");

            ulong hash = ComputeHash(str, bit64);
            if (_hashes.ContainsKey(hash))
                throw new HashCollisionException($"Hash '{hash}' of string '{str}' already exists within the hash dictionary.");

            _hashes.Add(hash, str);
        }

        /// <summary>
        /// Remove a hash from the hashes dictionary.
        /// </summary>
        /// <param name="hash">The hash to remove.</param>
        public void Remove(ulong hash)
        {
            _hashes.Remove(hash);
        }

        /// <summary>
        /// Clear the hashes dictionary of all hashes and strings.
        /// </summary>
        public void Clear()
        {
            _hashes.Clear();
        }
    }
}
