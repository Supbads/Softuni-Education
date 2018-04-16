package com.company;
import java.util.Scanner;

//type an integer less than 20
public class Problem_16_Calculate_N_Factorial {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        long n = sc.nextLong();
        if(n==0 || n==1){
            System.out.println("1");
            return;
        }
        else{
            Long g =runFactorial(n);
            System.out.println(g.toString());
        }
    }
    static long runFactorial(long n){
        if(n<=1){
            return 1;
        }
        else{
            n = n*runFactorial(n-1);
        }
        return n;
    }
}
