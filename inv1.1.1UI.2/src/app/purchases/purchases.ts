export class Purchases{
    PurchaseID!: Number;
    SupplierID: BigInteger | undefined;
    ProductID: BigInteger | undefined;
    CostOfPurchase: BigInteger | undefined;
    DateOfPurchase: string | undefined;
}