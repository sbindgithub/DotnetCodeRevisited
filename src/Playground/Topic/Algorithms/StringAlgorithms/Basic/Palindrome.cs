/*
Problem: Longest Substring Without Repeating Characters
Pattern: Sliding Window (Variable)
Data Structure: HashSet
Time Complexity: O(n)
Space Complexity: O(n)
Use Case: Streaming / log processing
Trade-off: Space vs speed
*/

using System;

//bool IsPalindrome(string s)
//{
//    int left = 0;
//    int right = s.Length - 1;

//    while (left < right)
//    {
//        if (s[left] != s[right])
//            return false;

//        left++;
//        right--;
//    }

//    return true;
//}
