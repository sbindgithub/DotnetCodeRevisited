/*
Problem:
Pattern:
Data Structure:
Time Complexity:
Space Complexity:
Notes:
*/

//bool IsAnagram(string s, string t)
//{
//    if (s.Length != t.Length) return false;

//    int[] count = new int[26];

//    foreach (char c in s)
//        count[c - 'a']++;

//    foreach (char c in t)
//        count[c - 'a']--;

//    foreach (int val in count)
//        if (val != 0) return false;

//    return true;
//}


//Examples

//Valid anagrams:

//"listen" ↔ "silent"
//"triangle" ↔ "integral"
//"evil" ↔ "vile"

//Invalid:

//"hello" ↔ "bello" → different characters
//"rat" ↔ "car" → mismatch