using FtdiSharp;

namespace FtdiSharpDemo;

public partial class DeviceInfoForm : Form
{
    readonly List<DeviceInfo> Devices = new();

    public DeviceInfoForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        Devices.Clear();

        FtdiManager ftman = new();
        foreach (var device in ftman.GetDevices())
        {
            Devices.Add(device);
            listBox1.Items.Add(device.ToString());
        }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex < 0)
            return;

        DeviceInfo device = Devices[listBox1.SelectedIndex];
        cbIsOpen.Checked = device.IsOpen;
        cbIsHighspeed.Checked = device.IsHighSpeed;
        lblType.Text = device.Type;
        lblID.Text = device.ID.ToString();
        lblLoc.Text = device.LocationID.ToString();
        lblSerial.Text = device.SerialNumber.ToString();
        lblDescription.Text = device.Description;
    }
}
