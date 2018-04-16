package com.company;
import java.util.*;


public class Problem_5_Lego_Blocks {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int numberOfRows = Integer.parseInt(sc.nextLine());

        ArrayList<ArrayList<Integer>> firstMatrix = new ArrayList<>();
        ArrayList<ArrayList<Integer>> secondMatrix = new ArrayList<>();

        readInputMatrix(sc, numberOfRows, firstMatrix);
        readInputMatrix(sc, numberOfRows, secondMatrix);

        boolean isRectangular = true;
        int length = firstMatrix.get(0).size() + secondMatrix.get(0).size();
        for (int i = 1; i <numberOfRows; i++) {
            if(length!=firstMatrix.get(i).size()+secondMatrix.get(i).size()){
                isRectangular=false;
            }
        }

        if(isRectangular){
            mergeMatrices(firstMatrix, secondMatrix);
            for (ArrayList<Integer> integers : firstMatrix) {
                System.out.println(integers);
            }
        }else{
            int count = 0;
            for (int i = 0; i < numberOfRows; i++) {
                count+= firstMatrix.get(i).size()+secondMatrix.get(i).size();
            }
            System.out.printf("The total number of cells is: %d", count);
        }


    }

    private static void mergeMatrices(ArrayList<ArrayList<Integer>> firstMatrix, ArrayList<ArrayList<Integer>> secondMatrix) {
        for (int i = 0; i < firstMatrix.size(); i++) {
            Collections.reverse(secondMatrix.get(i));
            firstMatrix.get(i).addAll(secondMatrix.get(i));
        }

    }

    private static void readInputMatrix(Scanner sc, int numberOfRows, ArrayList<ArrayList<Integer>> matrix) {
        for (int i = 0; i < numberOfRows; i++) {
            matrix.add(new ArrayList<>());
            String[] numsAsStrings = sc.nextLine().trim().split("\\s+");
            for (String numsAsString : numsAsStrings) {
                matrix.get(i).add(Integer.parseInt(numsAsString));
            }
        }
    }
}
