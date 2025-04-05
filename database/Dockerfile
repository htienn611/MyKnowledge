# Sử dụng image SQL Server mới nhất từ Microsoft
FROM mcr.microsoft.com/mssql/server:latest

# Thiết lập các biến môi trường cần thiết
ENV ACCEPT_EULA=${DB_ACCEPT_EULA} \
    SA_PASSWORD=${DB_SA_PASSWORD} \
    MSSQL_PID=${DB_MSSQL_PID}

EXPOSE ${DB_CONTAINER_PORT}

# Chạy SQL Server khi container khởi động
CMD ["/opt/mssql/bin/sqlservr"]
