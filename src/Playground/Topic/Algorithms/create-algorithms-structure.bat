@echo off
SET BASE=Algorithms

REM Root
mkdir %BASE% 2>nul

REM ================= Foundations =================
mkdir %BASE%\Foundations 2>nul
call :createFile "%BASE%\Foundations\BigONotationExamples.cs"

REM ================= Recursion =================
mkdir %BASE%\Recursion\Basics 2>nul
mkdir %BASE%\Recursion\Backtracking 2>nul
mkdir %BASE%\Recursion\Memoization 2>nul

call :createFile "%BASE%\Recursion\Basics\Fibonacci_Recursive.cs"
call :createFile "%BASE%\Recursion\Basics\Factorial.cs"
call :createFile "%BASE%\Recursion\Backtracking\Subsets.cs"
call :createFile "%BASE%\Recursion\Backtracking\Permutations.cs"
call :createFile "%BASE%\Recursion\Backtracking\NQueens.cs"
call :createFile "%BASE%\Recursion\Memoization\Fibonacci_DP.cs"
call :createFile "%BASE%\Recursion\Memoization\ClimbingStairs.cs"

REM ================= String Algorithms =================
mkdir %BASE%\StringAlgorithms\Basic 2>nul
mkdir %BASE%\StringAlgorithms\HashingBased 2>nul
mkdir %BASE%\StringAlgorithms\Advanced 2>nul

call :createFile "%BASE%\StringAlgorithms\Basic\Palindrome.cs"
call :createFile "%BASE%\StringAlgorithms\Basic\AnagramCheck.cs"
call :createFile "%BASE%\StringAlgorithms\HashingBased\RemoveDuplicates.cs"
call :createFile "%BASE%\StringAlgorithms\HashingBased\FirstNonRepeatingChar.cs"
call :createFile "%BASE%\StringAlgorithms\Advanced\KMPPatternSearch.cs"

REM ================= Two Pointers =================
mkdir %BASE%\TwoPointers\OppositeDirection 2>nul
mkdir %BASE%\TwoPointers\FastSlowPointer 2>nul

call :createFile "%BASE%\TwoPointers\OppositeDirection\TwoSumSorted.cs"
call :createFile "%BASE%\TwoPointers\OppositeDirection\ContainerWithMostWater.cs"
call :createFile "%BASE%\TwoPointers\FastSlowPointer\DetectCycle_LinkedList.cs"
call :createFile "%BASE%\TwoPointers\FastSlowPointer\FindMiddleElement.cs"

REM ================= Sliding Window =================
mkdir %BASE%\SlidingWindow\FixedWindow 2>nul
mkdir %BASE%\SlidingWindow\VariableWindow 2>nul

call :createFile "%BASE%\SlidingWindow\FixedWindow\MaxSumSubarray.cs"
call :createFile "%BASE%\SlidingWindow\VariableWindow\LongestSubstringWithoutRepeating.cs"
call :createFile "%BASE%\SlidingWindow\VariableWindow\MinimumWindowSubstring.cs"

REM ================= Hashing =================
mkdir %BASE%\Hashing\FrequencyCounting 2>nul
mkdir %BASE%\Hashing\LookupOptimization 2>nul

call :createFile "%BASE%\Hashing\FrequencyCounting\CountElements.cs"
call :createFile "%BASE%\Hashing\LookupOptimization\TwoSum_Unsorted.cs"
call :createFile "%BASE%\Hashing\LookupOptimization\ContainsDuplicate.cs"

REM ================= Sorting =================
mkdir %BASE%\Sorting\Basic 2>nul
mkdir %BASE%\Sorting\Efficient 2>nul

call :createFile "%BASE%\Sorting\Basic\BubbleSort.cs"
call :createFile "%BASE%\Sorting\Basic\SelectionSort.cs"
call :createFile "%BASE%\Sorting\Efficient\MergeSort.cs"
call :createFile "%BASE%\Sorting\Efficient\QuickSort.cs"

REM ================= Searching =================
mkdir %BASE%\Searching\BinarySearch 2>nul
mkdir %BASE%\Searching\Variants 2>nul

call :createFile "%BASE%\Searching\BinarySearch\BasicBinarySearch.cs"
call :createFile "%BASE%\Searching\BinarySearch\SearchInRotatedArray.cs"
call :createFile "%BASE%\Searching\Variants\LowerBound.cs"
call :createFile "%BASE%\Searching\Variants\UpperBound.cs"

REM ================= Dynamic Programming =================
mkdir %BASE%\DynamicProgramming\1D 2>nul
mkdir %BASE%\DynamicProgramming\2D 2>nul

call :createFile "%BASE%\DynamicProgramming\1D\Fibonacci.cs"
call :createFile "%BASE%\DynamicProgramming\1D\HouseRobber.cs"
call :createFile "%BASE%\DynamicProgramming\2D\LongestCommonSubsequence.cs"
call :createFile "%BASE%\DynamicProgramming\2D\Knapsack.cs"

REM ================= Greedy =================
mkdir %BASE%\Greedy 2>nul

call :createFile "%BASE%\Greedy\ActivitySelection.cs"
call :createFile "%BASE%\Greedy\MinimumCoins.cs"
call :createFile "%BASE%\Greedy\IntervalMerging.cs"

REM ================= Graph Algorithms =================
mkdir %BASE%\GraphAlgorithms\Traversal 2>nul
mkdir %BASE%\GraphAlgorithms\ShortestPath 2>nul

call :createFile "%BASE%\GraphAlgorithms\Traversal\BFS.cs"
call :createFile "%BASE%\GraphAlgorithms\Traversal\DFS.cs"
call :createFile "%BASE%\GraphAlgorithms\ShortestPath\Dijkstra.cs"
call :createFile "%BASE%\GraphAlgorithms\CycleDetection.cs"

REM ================= Tree Algorithms =================
mkdir %BASE%\TreeAlgorithms\Traversal 2>nul
mkdir %BASE%\TreeAlgorithms\Problems 2>nul

call :createFile "%BASE%\TreeAlgorithms\Traversal\InOrder.cs"
call :createFile "%BASE%\TreeAlgorithms\Traversal\PreOrder.cs"
call :createFile "%BASE%\TreeAlgorithms\Traversal\PostOrder.cs"
call :createFile "%BASE%\TreeAlgorithms\Problems\MaxDepth.cs"
call :createFile "%BASE%\TreeAlgorithms\Problems\LowestCommonAncestor.cs"

REM ================= Bit Manipulation =================
mkdir %BASE%\BitManipulation 2>nul

call :createFile "%BASE%\BitManipulation\SingleNumber.cs"
call :createFile "%BASE%\BitManipulation\CountBits.cs"

REM ================= Math Algorithms =================
mkdir %BASE%\MathAlgorithms 2>nul

call :createFile "%BASE%\MathAlgorithms\PrimeCheck.cs"
call :createFile "%BASE%\MathAlgorithms\GCD.cs"
call :createFile "%BASE%\MathAlgorithms\SieveOfEratosthenes.cs"

REM ================= Advanced Patterns =================
mkdir %BASE%\AdvancedPatterns\MonotonicStack 2>nul
mkdir %BASE%\AdvancedPatterns\PrefixSum 2>nul
mkdir %BASE%\AdvancedPatterns\UnionFind 2>nul

call :createFile "%BASE%\AdvancedPatterns\MonotonicStack\NextGreaterElement.cs"
call :createFile "%BASE%\AdvancedPatterns\PrefixSum\RangeSumQuery.cs"
call :createFile "%BASE%\AdvancedPatterns\UnionFind\DisjointSet.cs"

REM ================= Real World =================
mkdir %BASE%\RealWorldPatterns 2>nul

call :createFile "%BASE%\RealWorldPatterns\PaginationLogic.cs"

REM ================= Interview Notes =================
mkdir %BASE%\InterviewNotes 2>nul

call :createFile "%BASE%\InterviewNotes\PatternRecognition.cs"

echo Structure and .cs files created successfully.
pause
exit /b

:createFile
(
echo /*
echo Problem:
echo Pattern:
echo Data Structure:
echo Time Complexity:
echo Space Complexity:
echo Notes:
echo */
echo.
echo using System;
echo.
echo public class Solution
echo {
echo     public void Execute^(^)
echo     {
echo         // TODO
echo     }
echo }
) > "%~1"
exit /b