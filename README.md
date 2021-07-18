# IntroductionToFullStack

## Data

### Purpose

#### Tasks:

1. Create a Database

```CREATE DATABASE IF NOT EXISTS fullstackdemo;```

Run this in your preferred SQL Studio/Manager on your local db server

2. Create a db user

```CREATE USER 'otb'@'localhost' IDENTIFIED BY 'OtbOtb';```
```GRANT ALL PRIVILEGES ON fullstackdemo.* TO 'otb'@'localhost';```

```CREATE USER 'otb'@'%' IDENTIFIED BY 'OtbOtb';```
```GRANT ALL PRIVILEGES ON fullstackdemo.* TO 'otb'@'%';```

Run this in your preferred SQL Studio/Manager on your local db server

#### Links:
https://fluentmigrator.github.io/articles/quickstart.html?tabs=runner-in-process

## API

dotnet ef dbcontext scaffold "server=localhost;port=3307;user=otb;password=OtbOtb;database=fullstackdemo" Pomelo.EntityFrameworkCore.MySql -f

delete:

```
        public fullstackdemoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3307;user=otb;password=OtbOtb;database=fullstackdemo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }
```

``` docker build -f Dockerfile -t demoapi . ```

``` docker-compose up -d ```

### Purpose

#### Tasks:

#### Links:

## UI

### Purpose

#### Tasks:

#### Links: