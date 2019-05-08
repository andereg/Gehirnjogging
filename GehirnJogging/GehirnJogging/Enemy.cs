using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GehirnJogging
{
class Enemy
{

private static Enemy _enemy;

private Enemy()
{

}

/// <summary>
/// 
/// </summary>
/// <returns></returns>
public static Enemy GetInstance()
{
if (_enemy == null)
{
_enemy = new Enemy();
}
return _enemy;
}

/// <summary>
/// 
/// </summary>
public string enemyName { get; set; }

/// <summary>
/// 
/// </summary>
public double Health { get; set; }

}
}