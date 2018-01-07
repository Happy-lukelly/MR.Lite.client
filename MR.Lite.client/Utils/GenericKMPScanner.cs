using System;
using System.Collections.Generic;

namespace Utils
{
    /// <summary>
    /// 值类型的KMPScan类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericKMPScanner<T>
    {
        /// <summary>
        /// 查找指定模式串在主串中的第一个位置并立即返回,若没有完成 匹配则返回-1
        /// </summary>
        /// <param name="mainArr">主串</param>
        /// <param name="patternArr">模式串</param>
        /// <returns></returns>
        public int IndexOf(T[] mainArr, T[] patternArr)
        {
            int result = -1;
            int mainArrLen = mainArr == null ?throw new Exception("主串为null"): mainArr.Length;
            int patternLen = patternArr == null ? throw new Exception("模式串为null") : patternArr.Length;
            if (mainArrLen > patternLen)
            {
                int[] next = GetNextArr(patternArr);
                int mainPoint = 0, patternPoint = 0;
                int maxLoopCount = (mainArrLen - patternLen) + 1;
                while (mainPoint < maxLoopCount)
                {
                    for (; patternPoint < patternLen; patternPoint++)
                    {
                        //模式匹配错误
                        if (!mainArr[mainPoint+ patternPoint].Equals(patternArr[patternPoint]))
                        {
                            break;
                        }
                    }
                    //查找完成
                    if (patternPoint == patternLen)
                    {
                        result = mainPoint;
                        break;
                    }
                    else
                    //重新计算位置
                    {
                        int offset = 0;
                        offset = patternPoint - next[patternPoint];
                        mainPoint += offset;
                        patternPoint = next[patternPoint] == -1 ? 0 : next[patternPoint];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 查找指定模式串在主串中的第一个位置并返回所有位置的数组，若没有匹配则返回长度为0的数组
        /// </summary>
        /// <param name="mainArr"></param>
        /// <param name="patternArr"></param>
        /// <returns></returns>
        public int[] AllIndex(T[] mainArr, T[] patternArr)
        {
            int mainArrLen = mainArr == null ? throw new Exception("主串为null") : mainArr.Length;
            int patternLen = patternArr == null ? throw new Exception("模式串为null") : patternArr.Length;
            List<int> resultList = new List<int>();
            if (mainArrLen > patternLen)
            {
                int[] next = GetNextArr(patternArr);
                int mainPoint = 0, patternPoint = 0;
                int maxLoopCount = (mainArrLen - patternLen) + 1;
                while (mainPoint < maxLoopCount)
                {
                    for (; patternPoint < patternLen; patternPoint++)
                    {
                        //模式匹配错误
                        if (!mainArr[mainPoint + patternPoint].Equals(patternArr[patternPoint]))
                        {
                            break;
                        }
                    }
                    //查找完成
                    if (patternPoint == patternLen)
                    {
                        resultList.Add(mainPoint);
                        mainPoint+= patternLen;
                        patternPoint = 0;
                    }
                    else
                    //重新计算位置
                    {
                        int offset = 0;
                        offset = patternPoint - next[patternPoint];
                        mainPoint += offset;
                        patternPoint = next[patternPoint] == -1 ? 0 : next[patternPoint];
                    }
                }
            }
            return resultList.ToArray();
        }
        /// <summary>
        /// 计算Next数组
        /// </summary>
        /// <param name="patternArr"></param>
        /// <returns></returns>
        private int[] GetNextArr(T[] patternArr)
        {
            int length = patternArr.Length;
            int[] result = new int[length];
            result[0] = -1;
            int i = 0, j = -1;
            while (i < length - 1)
            {
                if (j == -1 || patternArr[i].Equals(patternArr[j]))
                {
                    result[++i] = ++j;
                }
                else
                {
                    j = result[j];        //回溯j指针
                }
            }
            return result;
        }


    }
}
