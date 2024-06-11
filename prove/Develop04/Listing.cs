class Listing : Activity{
    private static readonly string _self = "listing";
    private int _length;

    public Listing(int length, string datetime, string entryName) : base(datetime,entryName,"Listing",length){_length = length;}
}