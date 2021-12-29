using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GUIText ResultText;
    public int step = -1;
    public int selecteditems = 0;

    public const int nnode = 43;
    public int start = -1, end = -1;
    public int[,] adj = new int[nnode, nnode]
    {
   { 0,14,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,4,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 1
   { 14,0,14,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue } , // 2
   { int.MaxValue,14,0,14,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 3
   { int.MaxValue,int.MaxValue,14,0,  14,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 4
   { int.MaxValue,int.MaxValue,int.MaxValue,14,  0,14,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 5
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  14,0,14,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 6
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,14,0,14,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 7
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,14,0,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,14,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 8
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,0,  14,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  14,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 9
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,14,  0,14,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 10
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  14,0,14,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 11
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,14,0,14,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 12
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,14,0,14,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 13
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,14,0,  14,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 14
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,14,  0,14,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 15
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  14,0,int.MaxValue,int.MaxValue,4,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue },   // 16
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,0,int.MaxValue,int.MaxValue,  int.MaxValue,35,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,18,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 17
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,0,70,  int.MaxValue,int.MaxValue,35,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,66,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 18
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,4,int.MaxValue,70,0,  int.MaxValue,int.MaxValue,int.MaxValue,35,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 19
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,14,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  0,int.MaxValue,int.MaxValue,int.MaxValue,35,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 20
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,35,int.MaxValue,int.MaxValue,  int.MaxValue,0,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,4,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue },  // 21
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue, int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,35,int.MaxValue,  int.MaxValue,int.MaxValue,0,70,int.MaxValue,  35,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,4,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 22
   { 4,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,35,  int.MaxValue,int.MaxValue,70,0,int.MaxValue,  int.MaxValue,35,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 23
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,14,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  35,int.MaxValue,int.MaxValue,int.MaxValue,0,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 24
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,35,int.MaxValue,int.MaxValue,  0,int.MaxValue,35,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  15,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 25
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,35,int.MaxValue,  int.MaxValue,0,int.MaxValue,35,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,35,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 26
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  35,int.MaxValue,0,int.MaxValue,35,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,15,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 27
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,35,int.MaxValue,0,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,20,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 28
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,35,int.MaxValue,0,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  11,int.MaxValue,int.MaxValue,int.MaxValue }, // 29
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  0,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,23 }, // 30
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,18,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,0,32,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 31
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,66,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,32,0,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 32
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,4,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,0,108,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 33
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,4,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,108,0,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 34
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  15,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  0,20,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 35
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,35,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  20,0,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 36
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,15,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,0,21,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 37
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,21,0,14,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 38
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,20,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,14,0,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue }, // 39
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,11,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  0,28,int.MaxValue,int.MaxValue }, // 40
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  28,0,27,int.MaxValue }, // 41
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,27,0,27 }, // 42
   { int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  23,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,int.MaxValue,  int.MaxValue,int.MaxValue,27,0 }, // 43
    };
    public static int checkedpoints = 0;
    // 필요한 배열을 선언함.
    // distance[y]는 y까지의 최단거리.
    // S_node[]는 최단거리가 파악된 정점들의 집합.
    // public static int[] distance = new int[43];
    // public static int[] S_node = new int[43];
    public static List<int> path;
    public static List<int> S_node;

    public static string[] pointnames = { "2-1", "2-2", "2-3", "2-4", "2-5", "2-6", "2-7", "2-8", "2-9", "2-10", "2-11", "2-12", "2-13", "2-14", "2-15", "이동수업실B", "1층 계단 1", "1층 계단 2", "1층 계단 3", "1층 계단 4", "2층 계단 1", "2층 계단 2", "2층 계단 3", "2층 계단 4", "3층 계단 2", "3층 계단 3", "4층 계단 2", "4층 계단 3", "5층 계단 2", "5층 복도 끝", "생활지도부", "중앙현관", "보건실", "2층 교무실", "과학정보부", "생물실험실", "영어회화실", "지구과학실", "물리실험실", "미술실I", "미술실II", "음악실I", "음악실II" };
    public Dictionary<string, int> name2point;

    void Start()
    {
        name2point = new Dictionary<string, int>();
        foreach (string i in pointnames)
            name2point.Add(i, name2point.Count);

        ResultText.text = "선택하세요";
    }

    void Update()
    {
        if (selecteditems == 2 && start != -1 && end != -1)
        {
            step = Shortest_Path_Finder(start, end);
            //step = Shortest_Path_Finder(s, 40);

            UpdateResult();
        }
    }

    // find()는 출발지 x부터 가장 가까운 정점 m을 찾아주는 함수.
    int find(ref int[] dist)
    {
        int min = int.MaxValue, min_node = -1;

        // min은 가장 가까운 정점까지의 거리를 의미. 최솟값을 찾을 때까지 for loop을 돌며 갱신됨.
        // min_node는 가장 가까운 정점의 번호.

        min = int.MaxValue;   // INT_MAX는 정수 중 최대인 상수값, 즉 무한대에 가까운 수라고 보면 됨.
        for (int i = 0; i < nnode; i++)
            if (dist[i] < min && S_node.Contains(i))
            {
                min = dist[i];
                min_node = i;  // for loop을 돌며 제일 가까운 정점 i를 찾아준다.
            }

        return min_node;
    }


    // 한 출발지 x에 대해 모든 점들의 최단경로를 전부 정해주는 함수.
    int Shortest_Path_Finder(int start, int end)
    {
        // 모든 정점을 집합 S에서 제외시킨 채로 시작한다.
        path = new List<int>(nnode);
        S_node = new List<int>(nnode);
        int[] dist = new int[nnode];
        int[] prev = new int[nnode];

        for (int v = 0; v < nnode; v++)
        {
            dist[v] = int.MaxValue;
            prev[v] = -1;

            S_node.Add(v);
        }

        dist[start] = 0;

        while (S_node.Count > 0)
        {
            int u = find(ref dist);
            S_node.Remove(u);

            for (int v = 0; v < nnode; v++)
            {
                if (S_node.Contains(v) && adj[u, v] < int.MaxValue)
                {
                    int alt = dist[u] + adj[u, v];
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                    }
                }
            }
        }

        //List<int> path = new List<int>(nnode);
        int reverse = end;
        while (prev[reverse] != -1)
        {
            path.Add(reverse);
            reverse = prev[reverse];
        }

        //for (int i = nnode - 1; i >= 0; i--)
        //    path.Add(rpath[i]);
        path.Reverse();

        return dist[end];
    }


    void UpdateResult()
    {
        ResultText.text =  "약" + step + " 걸음 소요";
      
    }
}
