package com.company;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class Problem_4_Copy_jpg_File {

    public static final String FILE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem4/image.jpg";
    public static final String SAVE_PATH = "C:/Users/USER/IdeaProjects/Homework 3. Streams and Files/src/com/company/Problem4/my-copied-picture.jpg";

    public static void main(String[] args) throws IOException {
        FileInputStream fis = new FileInputStream(FILE_PATH);
        FileOutputStream fos = new FileOutputStream(SAVE_PATH);
        int byteContainer;
        while((byteContainer = fis.read())!=-1)
        {
            fos.write(byteContainer);
        }
        fis.close();
        fos.close();
    }
}
