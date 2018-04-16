package com.company.Problem_2.Exceptions;
import com.company.Problem_2.Customer;
import com.company.Problem_2.FoodProduct;
import com.company.Problem_2.Product;

public class CustomerInsufficientBalanceException extends ProductManagementException{
    public CustomerInsufficientBalanceException() {
        super("You do not have enough money to buy this product!");
    }

}

