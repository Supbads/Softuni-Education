package com.company;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

//Please contact us at: support@github.com.
//Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information.

public class Problem_8_Extract_Emails {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String text = sc.nextLine();
        Pattern emailPattern = Pattern
                .compile("[\\w\\-\\+]+(?:\\.[\\w\\-\\+]+)*@(?:[\\w-]+\\.)+[a-zA-Z]{2,7}");
        Matcher matcher = emailPattern.matcher(text);
        while (matcher.find()) {
            System.out.println(matcher.group());
        }

    }
}
