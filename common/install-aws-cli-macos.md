# How to install AWS Cli in macOS

### **Setting a Default AWS SSO Profile for AWS CLI**
If you want to use **AWS SSO** without having to always specify `--profile my-sso-profile`, you need to set your **SSO profile as the default** in AWS CLI.

---

## **Step 1: Identify Your AWS SSO Profile**
Run:
```sh
aws configure list-profiles
```
This will show all available AWS CLI profiles, including your **SSO profile**.

If you haven’t set up AWS SSO yet, run:
```sh
aws configure sso
```
and follow the prompts.

---

## **Step 2: Set the Default Profile in AWS Config**
Edit your AWS CLI configuration file:

```sh
nano ~/.aws/config
```

Find your AWS SSO profile, which looks like this:
```ini
[profile my-sso-profile]
sso_start_url = https://mycompany.awsapps.com/start
sso_region = us-east-1
sso_account_id = 123456789012
sso_role_name = AdministratorAccess
region = us-east-1
output = json
```

### **Convert it into the Default Profile**
Change `[profile my-sso-profile]` to `[default]`:
```ini
[default]
sso_start_url = https://mycompany.awsapps.com/start
sso_region = us-east-1
sso_account_id = 123456789012
sso_role_name = AdministratorAccess
region = us-east-1
output = json
```
Save the file (`CTRL + X`, then `Y` and `Enter`).

---

## **Step 3: Verify the Default Profile**
Run:
```sh
aws sts get-caller-identity
```
If it works **without needing `--profile my-sso-profile`**, then your default profile is set correctly.

---

## **Step 4: Automate AWS SSO Login**
Since AWS SSO requires **periodic logins**, you can automate it:

1. **Add This to Your `.bashrc` or `.zshrc`** (to always log in when you open a terminal):
   ```sh
   echo 'aws sso login' >> ~/.bashrc  # For Bash
   echo 'aws sso login' >> ~/.zshrc   # For Zsh
   ```
   Then reload:
   ```sh
   source ~/.bashrc  # For Bash
   source ~/.zshrc   # For Zsh
   ```

2. **Manually Refresh AWS SSO (Every 12 Hours)**
   ```sh
   aws sso login
   ```

---

## **Final Check**
After following these steps:
```sh
aws sts get-caller-identity
```
- If it works **without `--profile`**, your **SSO profile is now the default**.
- If you see **"The security token included in the request is invalid"**, run:
  ```sh
  aws sso login
  ```

---

### **Summary**
✅ Set your AWS SSO profile as `[default]` in `~/.aws/config`.  
✅ No need to pass `--profile my-sso-profile` anymore.  
✅ Run `aws sso login` every **12 hours** to refresh authentication.  

Now, AWS CLI will **always use your SSO profile by default**! 🚀 Let me know if you need more help.