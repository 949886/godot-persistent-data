using Godot;
using SQLite;
using System;
using System.IO;

public partial class SQLiteTest : Node
{
	private SQLiteConnection _db;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		string databasePath = Path.Combine(ProjectSettings.GlobalizePath("res://sqlite"), "test.sqlite");

		_db = new SQLiteConnection(databasePath);
		_db.CreateTable<Stock>();
		_db.CreateTable<Valuation>();

		GetStocks();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// AddStock();
	}

	public void AddStock()
	{
		// Crate a random stock
		var stock = new Stock
		{
			Symbol = Guid.NewGuid().ToString().Substring(0, 4)
		};

		_db.Insert(stock);
	}

	public void GetStocks()
	{
		var stocks = _db.Query<Stock>("SELECT * FROM Stocks");

		foreach (var stock in stocks)
		{
			Console.WriteLine(stock.Symbol);
		}
	}


	[Table("Stocks")]
	public class Stock
	{
		[PrimaryKey, AutoIncrement]
		[Column("id")]
		public int Id { get; set; }

		[Column("symbol")]
		public string Symbol { get; set; }
	}

	[Table("Valuation")]
	public class Valuation
	{
		[PrimaryKey, AutoIncrement]
		[Column("id")]
		public int Id { get; set; }

		[Indexed]
		[Column("stock_id")]
		public int StockId { get; set; }

		[Column("time")]
		public DateTime Time { get; set; }

		[Column("price")]
		public decimal Price { get; set; }
	}
}
