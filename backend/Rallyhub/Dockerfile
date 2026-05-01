# bước 1: môi trường xây dựng (build environment)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY Rallyhub.Api/*.csproj ./Rallyhub.Api/
COPY Rallyhub.Repository/*.csproj ./Rallyhub.Repository/
COPY Rallyhub.Service/*.csproj ./Rallyhub.Service/

# chạy lệnh khôi phục
RUN dotnet restore ./Rallyhub.Api/Rallyhub.Api.csproj

# sao chép toàn bộ mã nguồn còn lại
COPY . ./

# đóng gói dự án thành các tệp nhị phân siêu nhẹ
RUN dotnet publish ./Rallyhub.Api/Rallyhub.Api.csproj -c Release -o out

# bước 2: môi trường chạy thực tế (runtime environment)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# mở cổng mạng nội bộ
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# lệnh khởi động ứng dụng
ENTRYPOINT ["dotnet", "Rallyhub.Api.dll"]