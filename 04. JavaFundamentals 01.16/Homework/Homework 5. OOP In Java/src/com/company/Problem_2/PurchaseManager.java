package com.company.Problem_2;
import com.company.Problem_2.Exceptions.*;

public final class PurchaseManager {
    private PurchaseManager() {
    }

    public static void processPurchase(Customer customer, Product product) throws ProductManagementException {
        if (product instanceof FoodProduct) {
            if (((FoodProduct) product).isExpired()) {
                throw new ProductHasExpiredException();
            }
        }
        if(product.getQuantity()<1){
            throw new ProductOutOfStockException();
        }
        if (product.getAgeRestrictionLevel() == AgeRestriction.Adult &&
                customer.getAge() < 18) {
            throw new CustomerNoPermissionToBuyException();
        }
        if (customer.getBalance()-product.getPrice()<0) {
            throw new CustomerInsufficientBalanceException();
        }
        customer.setBalance(customer.getBalance()-product.getPrice());
        product.setQuantity(product.getQuantity() - 1);

    }
}
