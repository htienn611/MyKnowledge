FROM mcr.microsoft.com/dotnet/sdk:latest

# Đặt thư mục làm việc
WORKDIR /workspace

# Cài đặt các công cụ cần thiết
RUN apt-get update && apt-get install -y nano git curl

ENV PATH="/root/.dotnet/tools:$PATH"
#RUN dotnet add package Microsoft.EntityFrameworkCore.SqlServer
#RUN dotnet add package Microsoft.EntityFrameworkCore.Design
#RUN dotnet add package Microsoft.AspNetCore.Mvc.Core
RUN dotnet tool install --global dotnet-ef

# Khôi phục các package đã cài
#RUN dotnet restore

# Thiết lập shell mặc định
CMD ["bash"]
