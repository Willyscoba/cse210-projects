class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer, List<Product> products)
    {
        this.customer = customer;
        this.products = products;
    }
    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (Product product in products)
        {
            totalCost += product.GetTotalCost();
        }

        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }
    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in products)
        {
            packingLabel += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return packingLabel;
    }
    public string GetShippingLabel()
    {
        return $"Customer Name: {customer.GetName()}\nAddress: {customer.GetAddress()}";
    }
}