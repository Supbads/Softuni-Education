package com.company;
import java.util.ArrayList;
import java.util.Scanner;
//h e l l o
//l o w
public class Problem_9_Combine_Lists_of_Letters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        String firstLine = sc.nextLine();
        char[] firstLineToCharArr = firstLine.toCharArray();
        ArrayList<Character> firstList = new ArrayList<>();
        for (int i = 0; i < firstLineToCharArr.length; i++) {
            if(firstLineToCharArr[i] != ' ') {
                firstList.add(firstLineToCharArr[i]);
            }
            else{
                continue;
            }
        }
        
        String secondLine = sc.nextLine();
        char[] secondLineToCharArr = secondLine.toCharArray();
        ArrayList<Character> secondList = new ArrayList<>();
        for (int i = 0; i < secondLineToCharArr.length; i++) {
            if(secondLineToCharArr[i]!= ' '){
                secondList.add(secondLineToCharArr[i]);
            }
        }

        for (int i = 0; i < secondList.size(); i++) {
            if(!firstList.contains(secondList.get(i))){
                firstList.add(secondList.get(i));
            }
        }

        System.out.println(firstList);
        for (Character c : firstList) {
            System.out.print(c + " ");
        }
    }
}
