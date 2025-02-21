# How to install Uvicorn with Poetry

To install **Uvicorn** on macOS using **Poetry**, follow these steps:

### **1. Install Poetry (if not installed)**
If you don’t have **Poetry** installed, install it using:
```sh
curl -sSL https://install.python-poetry.org | python3 -
```
Then, ensure it's added to your PATH:
```sh
export PATH="$HOME/.local/bin:$PATH"
```
Verify installation:
```sh
poetry --version
```

---

### **2. Create a New Poetry Project (if needed)**
If you don't have a Poetry project yet, create one:
```sh
poetry new my_project
cd my_project
```

If you already have a project, navigate to the directory:
```sh
cd /path/to/your/project
```

---

### **3. Add Uvicorn to Your Poetry Project**
To install Uvicorn, use:
```sh
poetry add uvicorn
```
This installs Uvicorn and adds it to your `pyproject.toml` dependencies.

If you need Uvicorn only for development (e.g., for running a FastAPI app locally), install it as a dev dependency:
```sh
poetry add uvicorn --group dev
```

---

### **4. Run Uvicorn**
If you’re using FastAPI or another ASGI framework, you can start the server with:
```sh
poetry run uvicorn app:app --reload
```
Replace `app:app` with your module and app instance (e.g., `main:app` if you have `app = FastAPI()` in `main.py`).

---

### **5. (Optional) Install Uvicorn with Extra Features**
Uvicorn has optional dependencies like `uvloop` and `httptools` for better performance. Install them with:
```sh
poetry add uvicorn[standard]
```

Now, Uvicorn is installed and ready to use on macOS via Poetry! 🚀