Q1
新的C#script掛上去後,要怎麼消除綠色加號
A1
C#script必須添加在Prefabs物件裡面;將Hirearchy內的遊戲物件刪除後,從Prefabs內將物件重新拉進Hirearchy
或是右上小點 > Modified Component > Apply to Prefab ...


Q2


A2
unity CharacterController 角色碰撞偵測
王啟榮 發表於 2017/12/03_21:06

使用 CharacterController.Move 方法移動角色時，可搭配以下判斷得知膠囊體接觸其他 collider 的情形。

　CharacterController controller = GetComponent<CharacterController>();

　if (controller.collisionFlags == CollisionFlags.None){　}　// 完全沒碰到
　if ((controller.collisionFlags & CollisionFlags.Sides) != 0){　}　// 側邊有碰到
　if (controller.collisionFlags == CollisionFlags.Sides){　}　// 只有側邊碰到
　if ((controller.collisionFlags & CollisionFlags.Above) != 0){　}　// 上方有碰到(天花板)
　if (controller.collisionFlags == CollisionFlags.Above){　}　// 只有上方碰到(天花板)
　if ((controller.collisionFlags & CollisionFlags.Below) != 0){　}　// 下方有碰到(地板)
　if (controller.collisionFlags == CollisionFlags.Below){　}　// 只有下方碰到(地板)