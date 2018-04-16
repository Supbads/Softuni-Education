package com.company;
import jdk.nashorn.internal.runtime.regexp.joni.Regex;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


//Java is a set of several computer software products and specifications from Oracle Corporation that provides a system for developing application software and deploying it in a cross-platform computing environment. Java is used in a wide variety of computing platforms from embedded devices and mobile phones on the low end, to enterprise servers and supercomputers on the high end.
// ^ copy by going to the rightmost side and ctrl+c (it'll copy the entire line.
//Welcome to the Software University (SoftUni)!

public class Problem_5_Count_All_Words {
    public static void main(String[] args) {
        String pattern = "\\b([a-zA-Z]+)\\b";
        Pattern pat = Pattern.compile(pattern);

        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();

        Matcher match = pat.matcher(text);
        int words = 0;
        while(match.find()){
            words++;
        }

        System.out.println(words);

    }
}
