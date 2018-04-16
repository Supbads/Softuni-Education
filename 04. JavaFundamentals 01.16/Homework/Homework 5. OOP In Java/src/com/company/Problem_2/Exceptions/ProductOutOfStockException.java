package com.company.Problem_2.Exceptions;

public class ProductOutOfStockException extends ProductManagementException {
    public ProductOutOfStockException() {
        super("We're sorry, this product is out of stock.");
    }
}
