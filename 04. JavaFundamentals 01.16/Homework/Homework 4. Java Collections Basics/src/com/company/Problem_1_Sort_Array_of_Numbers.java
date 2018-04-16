package com.company;
import java.util.Scanner;

//7
//6 5 4 10 -3 120 4
//3
//10 9 8

public class Problem_1_Sort_Array_of_Numbers {

    public static void main(String[] args) {
	    Scanner sc = new Scanner(System.in);
        int[] array = new int[sc.nextInt()];

        for (int i = 0; i < array.length; i++) {
            array[i]=sc.nextInt();
        }
        runSelectionSort(array);
        for (int i : array) {
            System.out.print(i+" ");
        }

    }
    static void runSelectionSort(int[] arr){
        for (int i = 0; i < arr.length-1; i++) {

            int currecntSelectedIndex = i;
            int smallerThanCurrecntIndex=currecntSelectedIndex;
            boolean action = false;

            for (int j = i+1; j < arr.length; j++) {
                if(arr[j]<arr[smallerThanCurrecntIndex]){
                    smallerThanCurrecntIndex = j;
                    action=true;
                }
            }

            if(action){
                int temp = arr[currecntSelectedIndex];
                arr[currecntSelectedIndex] = arr[smallerThanCurrecntIndex];
                arr[smallerThanCurrecntIndex]=temp;
            }
        }
    }
}
