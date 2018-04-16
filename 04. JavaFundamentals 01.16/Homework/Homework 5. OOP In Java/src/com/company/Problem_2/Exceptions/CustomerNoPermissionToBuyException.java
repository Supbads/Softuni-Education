package com.company.Problem_2.Exceptions;

public class CustomerNoPermissionToBuyException extends ProductManagementException {
    public CustomerNoPermissionToBuyException() {
        super("You are too young to buy this product!");
    }
}
