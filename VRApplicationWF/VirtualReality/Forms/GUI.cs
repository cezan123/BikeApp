using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using VRApplicationWF.VirtualReality.Scripts;

namespace VRApplicationWF.VirtualReality.Forms
{
    public partial class GUI : Form
    {
        private readonly Connection cw;
        private readonly JSONMethods jsonmethods;
        private string currentTime;



        public GUI(object connection, string id)
        {
            InitializeComponent();

            cw = (Connection)connection;
            jsonmethods = new JSONMethods(id);


            DoStuff();


        }

        private void DoStuff()
        {


            Console.WriteLine(cw.WriteReadData(jsonmethods.ResetScene()));


            cw.WriteReadData(jsonmethods.AddNode("data/NetworkEngine/models/bike/bike_anim.fbx", "Bike", "Armature|Fietsen", true, 0.02f));


            Console.WriteLine(cw.WriteReadData(jsonmethods.GetNode("Camera")));




            string uuidGP = JsonConvert.DeserializeObject<RootObject>(cw.WriteReadData(jsonmethods.GetNode("GroundPlane"))).data.data.data[0].uuid;
            string uuidCamera = JsonConvert.DeserializeObject<RootObject>(cw.WriteReadData(jsonmethods.GetNode("Camera"))).data.data.data[0].uuid;
            Console.WriteLine(cw.WriteReadData(jsonmethods.GetNode("Bike")));
            string uuidBike = JsonConvert.DeserializeObject<RootObject>(cw.WriteReadData(jsonmethods.GetNode("Bike"))).data.data.data[0].uuid;
            Console.WriteLine("uuidcamera: " + uuidCamera);
            Console.WriteLine("uuidBike: " + uuidBike);

            Console.WriteLine(cw.WriteReadData(jsonmethods.AddNodePanel("Panel", uuidCamera)));
            jsonmethods.panelUUID = JsonConvert.DeserializeObject<RootObject>(cw.WriteReadData(jsonmethods.GetNode("Panel"))).data.data.data[0].uuid;

            Console.WriteLine(cw.WriteReadData(jsonmethods.GetScene()));

            Console.WriteLine(uuidBike);


            Console.WriteLine(cw.WriteReadData(jsonmethods.UpdateNode(uuidCamera)));

            Console.WriteLine(cw.WriteReadData(jsonmethods.UpdateNodeParent(uuidCamera, uuidBike)));

            Console.WriteLine(cw.WriteReadData(jsonmethods.RemoveObject(uuidGP)));


            Console.WriteLine(cw.WriteReadData(jsonmethods.SetTime()));

            // not using this method because we prefer the normal skybox
            //   Console.WriteLine(cw.writeReadData(jsonmethods.addSkyBox()));

            Console.WriteLine(cw.WriteReadData(jsonmethods.AddNodeWater("Water")));



            Console.WriteLine(cw.WriteReadData(jsonmethods.AddFlatTerrain()));



            string tnuuid = cw.WriteReadData(jsonmethods.AddNodeTerrain("test")).Substring(124, 36);

            string addlayer = jsonmethods.AddLayer(tnuuid, "data/NetworkEngine/textures/tarmac_diffuse.png",
                "data/NetworkEngine/textures/terrain/grass_green_d.jpg");
            Console.WriteLine(cw.WriteReadData(addlayer));


            string uuid = cw.WriteReadData(jsonmethods.AddRoute());
            Console.WriteLine(uuid);
            uuid = uuid.Substring(110, 36);


            Console.WriteLine(cw.WriteReadData(jsonmethods.AddRoad(uuid)));

            Console.WriteLine(cw.WriteReadData(jsonmethods.FollowRoute(uuidBike)));



            //doesn't work?
            //Console.WriteLine(cw.writeReadData(jsonmethods.showRoute(true)));

            Console.WriteLine(cw.WriteReadData(jsonmethods.SetPanelClearColor()));

            currentTime = DateTime.Now.ToString("HH:mm");
            Console.WriteLine(currentTime);
            Console.WriteLine("klaar");


        }

        private void button1_SpawnObjects(object sender, EventArgs e)
        {
            Console.WriteLine(cw.WriteReadData(jsonmethods.AddNode(filepath.Text, nodeName.Text, "", false, float.Parse(scale.Text), Int32.Parse(spawnX.Text), Int32.Parse(spawnY.Text), Int32.Parse(spawnZ.Text))));
        }

        private void button2_GetScene(object sender, EventArgs e)
        {
            Console.WriteLine(cw.WriteReadData(jsonmethods.GetScene()));
        }

        private void button3_resetScene(object sender, EventArgs e)
        {
            Console.WriteLine(cw.WriteReadData(jsonmethods.ResetScene()));
        }

        //calls the method doStuff to create an in advanced generated scene when button is pressed
        private void button4_doStuff(object sender, EventArgs e)
        {
            DoStuff();
        }


        //method changes speed on the panel(display) and the moving speed of the biker in scene
        public void ChangeSpeed(double speed, string duration, double distance, double calories)
        {

            cw.WriteData(jsonmethods.ClearPanel());

            Console.WriteLine(cw.WriteReadData(jsonmethods.AddPanelText("Speed: " + speed + " km/h", 50.0f, 20.0f)));



            cw.WriteReadData(jsonmethods.AddPanelText("Duration: " + duration, 100.0f, 20.0f));

            cw.WriteReadData(jsonmethods.AddPanelText("Distance: " + distance + " km", 150.0f, 20.0f));

            cw.WriteReadData(jsonmethods.AddPanelText("Calories: " + calories + " kcal", 200.0f, 20.0f));

            cw.WriteReadData(jsonmethods.AddPanelText("Time: " + DateTime.Now.ToString("HH:mm"), 390.0f, 320.0f));

            cw.WriteData(jsonmethods.swapPanel());
        }
    }
}
