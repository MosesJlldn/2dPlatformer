using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class DiamondSquareAlg
	{	

		public DiamondSquareAlg ()
		{
		}

		public static void calculate(Vector2 v1, Vector2 v2, float roughness, List<Vector2> points) {
			
			int length = (int) Math.Round(Vector2.Distance (v1, v2));
			int horizontal_distance = (int) Math.Round(v2.x - v1.x);
			int vertical_distance = (int) Math.Round(v2.y - v1.y);

			Vector2 result = new Vector2 ((v1.x + v2.x) / 2, (v1.y + v2.y) / 2);

			bool flag = (UnityEngine.Random.value > 0.5f);
			float displacement = 0;

			displacement = flag ? roughness * length : -roughness * length;

			result = new Vector2 (result.x, result.y + displacement);
			points.Add (result);

			if (horizontal_distance - 1 > 2) {
				
				calculate (v1, result, roughness, points);
				calculate (result, v2, roughness, points);
			}
		}
	}
}