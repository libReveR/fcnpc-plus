using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;
using FCNPC;

public class MyGameMode : BaseMode
{
    private FCNPC npc;

    protected override void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);
        Console.WriteLine("SA-MP server initialized!");

        // NPC oluşturma ve spawn etme
        npc = new FCNPC("MyNPC");
        npc.Spawn(new Vector3(0, 0, 3));

        // NPC'yi belirli bir rotada yürütme
        npc.GoTo(new Vector3(100, 100, 3));

        // NPC'ye animasyon oynatma
        npc.PlayAnimation("PED", "WALK", 4.1f, true, false, false, false, 0);
    }

    protected override void OnPlayerConnected(BasePlayer player, EventArgs e)
    {
        base.OnPlayerConnected(player, e);
        player.SendClientMessage("Welcome to the server!");
    }

    protected override void OnPlayerCommandText(BasePlayer player, CommandTextEventArgs e)
    {
        base.OnPlayerCommandText(player, e);

        if (e.Text == "/followme")
        {
            if (npc != null)
            {
                npc.Follow(player);
                player.SendClientMessage("NPC is now following you!");
            }
        }
        else if (e.Text == "/attack")
        {
            if (npc != null)
            {
                npc.Attack(player);
                player.SendClientMessage("NPC is now attacking you!");
            }
        }
        else if (e.Text == "/drive")
        {
            if (npc != null)
            {
                var vehicle = BaseVehicle.Create(VehicleModelType.Infernus, new Vector3(0, 0, 3), 0);
                npc.PutInVehicle(vehicle, 0);
                npc.DriveTo(new Vector3(200, 200, 3));
                player.SendClientMessage("NPC is now driving!");
            }
        }
    }
}
