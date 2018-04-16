package com.company;
import java.util.Scanner;

//Welcome to the Software University (SoftUni)! Welcome to programming.
//welcome
//It's OK, I'm in.
//i
public class Problem_6_Count_Specified_Word {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        String word = sc.next();
        String[] words = text.split("([\\W])+");
        int count = 0;
        for (String currentWord : words) {
            if (currentWord.equalsIgnoreCase(word)) {
                count++;
            }
        }
        System.out.println(count);
    }
}
