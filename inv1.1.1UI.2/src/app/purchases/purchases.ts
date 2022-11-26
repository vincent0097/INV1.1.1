export class Purchases{
    purchaseID!: Number;
    supplierID: BigInteger | undefined;
    productID: BigInteger | undefined;
    costOfPurchase: BigInteger | undefined;
    totalCost: BigInteger | undefined;
    dateOfPurchase: string | undefined;
}