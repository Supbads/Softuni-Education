package com.company;
import java.util.Scanner;

//Welcome to the Software University (SoftUni)! Welcome to programming. Programming is wellness for developers, said Maxwell.
//wel
//ababa caba
//aba

public class Problem_7_Count_Substring_Occurrences {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine().toLowerCase();
        String substring = sc.next().toLowerCase();

        int count = countSubstringOccurrences(text,substring);
        System.out.println(count);

    }
    static int countSubstringOccurrences(String text, String substring){
        int index = 0;
        int count =0;

        while((index = text.indexOf(substring , index))!= -1){
            index++;
            count++;
        }

        return count;
    }

}
