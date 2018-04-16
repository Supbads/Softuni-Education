package com.company;
import java.util.ArrayList;
import java.util.Scanner;

//hi yes yes yes bye
//1 1 2 2 3 3 4 4 5 5

public class Problem_2_Sequences_of_Equal_Strings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        String[] array = sc.nextLine().split(" ");
        System.out.print(array[0]);
        for (int i = 1; i < array.length; i++) { //won't throw exception
            if (array[i].equals(array[i - 1])) {
                System.out.print(" " + array[i]);
            } else {
                System.out.println();  //due to first element
                System.out.print(array[i]);
            }
        }
    }
}
