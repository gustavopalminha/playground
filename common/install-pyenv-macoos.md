# Install Pyenv in macOS

If running `xcode-select --install` doesn't trigger the installation popup, here are several troubleshooting steps to resolve the issue:

---

### 🚩 **1. Check if Command Line Tools Are Already Installed**

Run the following command to verify:

```bash
xcode-select -p
```

- **If installed**, you'll see something like:
  ```
  /Library/Developer/CommandLineTools
  ```
- **If not installed**, it will return:
  ```
  xcode-select: error: unable to get active developer directory
  ```

---

### 🔄 **2. Manually Trigger the Installation**

#### **Remove Any Existing Incomplete Installations:**

```bash
sudo rm -rf /Library/Developer/CommandLineTools
```

#### **Re-run the Installer:**

```bash
xcode-select --install
```

---

### 🌐 **3. Install via Software Update (Alternative Method)**

If the popup still doesn’t appear, try using `softwareupdate`:

```bash
softwareupdate --list
```

Look for something like `Command Line Tools for Xcode`.

Then install it:

```bash
sudo softwareupdate -i "Command Line Tools for Xcode-<version>"
```

*(Replace `<version>` with the exact version shown in the list.)*

---

### ⚙️ **4. Download Directly from Apple Developer Website**

1. Go to [Apple Developer Downloads](https://developer.apple.com/download/more/).
2. Sign in with your Apple ID.
3. Search for **"Command Line Tools"**.
4. Download the `.dmg` for your macOS version and install it manually.

---

### 🔧 **5. Reset `xcode-select` Configuration**

```bash
sudo xcode-select --reset
xcode-select --install
```

---

### ✅ **6. Verify After Installation**

Once you've installed the tools, verify with:

```bash
gcc --version
make --version
```

---

Let me know which method works for you, or if you encounter any errors during the process. 🚀