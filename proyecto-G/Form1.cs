using System.Text.Json;
using System.Windows.Forms;
using proyecto_G.dto;
using proyecto_G.service;
using proyecto_G.utilities;

namespace proyecto_G
{
    public partial class Form1 : Form
    {

        List<DeviceLocation> deviceLocations = new List<DeviceLocation>();
        private static MqttService mqttService;

        public Form1()
        {
            InitializeComponent();
            mqttService = new MqttService();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            mqttService.Start(DevConstants.HIVE_HOST_BROKER_MQTT.Item1, DevConstants.MQTT_ID_TOPIC_SERVER_001, message =>
            {
                string unescapedJsonString = message.Replace("\\", ""); // JsonConvert.DeserializeObject<string>(quoted);
                LocationDTO locationDTO = JsonSerializer.Deserialize<LocationDTO>(unescapedJsonString);
                
                if (gridView.InvokeRequired)
                {
                    gridView.Invoke(new MethodInvoker(delegate
                    {
                        gridView.ColumnCount = 6;

                        gridView.Columns[0].Name = "dispositivo";
                        gridView.Columns[1].Name = "fecha";
                        gridView.Columns[2].Name = "coordenadas";
                        gridView.Columns[3].Name = "estado";
                        gridView.Columns[4].Name = "velocidad";
                        gridView.Columns[5].Name = "ver";
                        gridView.Rows.Clear();
                        // gridView.Rows.Add(item.Device, item.Fecha, item.Coordenadas, item.Estado, item.Velocidad, item.Ver);
                        // https://www.google.com/maps/search/?api=1&query=-11.98946%2C-77.06689
                        gridView.Rows.Add("MG001", locationDTO.FechaHora, $"{locationDTO.Latitud},{locationDTO.Longitud}", "Conectado", locationDTO.Velocidad,
                            $"https://www.google.com/maps/search/?api=1&query={locationDTO.Latitud}%2C{locationDTO.Longitud}");

                    }));
                } 
            });
        }

  
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void btnCoordenadas_Click(object sender, EventArgs e)
        {
                        
        }

        private List<DeviceLocation> GetDeviceLocations()
        {
            List<DeviceLocation> deviceLocations = new List<DeviceLocation>();
            deviceLocations.Add(new DeviceLocation("mg001", "27-01-2022 20:00:00", "-11.100,-17.00", "conectado", "40km", "maps.google.com/?lat=-11.100%lng=-17.00"));
            deviceLocations.Add(new DeviceLocation("mg002", "27-01-2022 10:00:00", "-11.100,-17.00", "conectado", "50km", "maps.google.com/?lat=-11.100%lng=-17.00"));
            return deviceLocations;
        }
    }
}