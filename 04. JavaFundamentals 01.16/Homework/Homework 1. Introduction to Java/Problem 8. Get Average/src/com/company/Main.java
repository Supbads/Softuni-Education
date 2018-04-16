package com.company;
import java.util.Scanner;
public class Main {

    public static void main(String[] args) {
    Scanner sc = new Scanner(System.in);
        System.out.println("Enter 3 number on separe lines.");
        double firstNumber = Double.parseDouble(sc.nextLine());
        double secondNumber = Double.parseDouble(sc.nextLine());
        double thirdNumber = Double.parseDouble(sc.nextLine());
        double avrg = getAverage(firstNumber,secondNumber,thirdNumber);
        System.out.println( String.format( "%.2f", avrg ));

    }
    static double getAverage(double a, double b, double c){
        double average = 0;
        average = (a + b +c)/3;
        return average;
    }
}
