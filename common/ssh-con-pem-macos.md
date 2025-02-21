# How to open an SSH connection using a `.pem` file on macOS Terminal, follow these steps:

### **1. Open Terminal**
You can do this by pressing `Command (⌘) + Space`, typing **Terminal**, and hitting **Enter**.

### **2. Navigate to the Directory with the `.pem` File**
If your `.pem` file is in **Downloads**, navigate there using:
```bash
cd ~/Downloads
```
Or specify the correct path where your `.pem` file is located.

### **3. Set the Correct Permissions for the `.pem` File**
Ensure the `.pem` file has the right permissions to be used by SSH:
```bash
chmod 400 your-key.pem
```

### **4. Connect to the Remote Server**
Use the following SSH command:
```bash
ssh -i your-key.pem username@server-ip
```
Replace:
- `your-key.pem` with your `.pem` file name.
- `username` with the appropriate username (e.g., `ec2-user` for AWS, `ubuntu` for Ubuntu servers).
- `server-ip` with the remote server’s public IP or hostname.

### **5. Verify Connection**
If successful, you should be logged into your remote server.

#### **Example for AWS EC2 Instance**
For an AWS EC2 instance with an Ubuntu AMI:
```bash
ssh -i my-key.pem ubuntu@ec2-12-34-56-78.compute-1.amazonaws.com
```

For an AWS EC2 instance with an Amazon Linux AMI:
```bash
ssh -i my-key.pem ec2-user@ec2-12-34-56-78.compute-1.amazonaws.com
```

Let me know if you need further assistance! 🚀