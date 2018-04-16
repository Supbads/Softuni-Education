package com.company;
import java.util.Scanner;

public class Problem_4_Letters_change_Numbers {
    //A = 65 ascii ->  -64
    // A  B  C -> /    |  a b c -> *
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\s+");
        double totalSum =0.0;
        for (String s : input) {
            char firstChar = s.charAt(0);
            char lastChar = s.charAt(s.length()-1);
            double num = Integer.parseInt(s.substring(1,1+s.length()-2));  //(1,s.length()-1)
            if((int)firstChar-64 >=1 && (int)firstChar-64<=26){ // Uppercase
                num /= (int)firstChar-64;
            }else{
                num *= (int)firstChar-96;
            }
            if((int)lastChar-64 >=1 && (int)lastChar-64<=26){ // Uppercase
                num -= (int)lastChar-64;
            }else{
                num += (int)lastChar-96;
            }
            totalSum+= num;
        }
        System.out.printf("%.2f",totalSum);

    }
}
