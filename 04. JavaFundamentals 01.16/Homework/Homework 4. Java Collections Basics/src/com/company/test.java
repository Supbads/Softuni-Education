package com.company;

public class test {
    public static void main(String[] args) {
        String str =  "x is x is x is x";
        int i = str.indexOf('x');
        while(i >= 0) {
            System.out.println(i);
            i = str.indexOf('x', i+1);
        }
    }
}
