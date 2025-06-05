using System;
using VSDotnetClass.Dayfour;
using VSDotnetClass.Daythree;

class Program
{
    static void Main()
    {       
        //---------DAY 4---------
        LinqSyn.RunPrgm();
        Product.RunProduct();
        MixedItemEg.RunMixeditem();

        Supplier supplier = new Supplier();
        supplier.RunSupplier();
        supplier.RunSetOperations();
        supplier.RunSkipEg();

        AggregateEg.RunAggregate();
        AggregateEg.RunElementOperators();

	 #region
        //---------DAY 3---------
        //EnumEg.Enumrun();
        //GenericSwap.Genericrun();
        //Generic.Genclass();
        //CollectionEg.Runprgm();
        //HashEg.HashRun();
        //Assignment.Question1();
        //Assignment.Question2();
        //Assignment.Question3();
        //Assignment.Question4();
        //Assignment.Question5();
        //Assignment.Question6();
        //Assignment.Question7();
        //Assignment.Question8();
        //Assignment.Question9();
        #endregion

        Console.ReadLine();
    }
}
