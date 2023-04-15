using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
	public SmugglersData smugglersData;
	public VehiclesData vehiclesData;
	public GoodsData goodsData;
	public WrappingsData wrappingsData;
	public TraitsData traitsData;
}