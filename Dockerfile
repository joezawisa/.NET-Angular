# Build front end
FROM node:20 AS frontend
WORKDIR /App
# Install npm project dependencies
COPY frontend/package*.json .
RUN npm install
# Compile
COPY frontend .
RUN npm run build

# Build back end
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS backend
WORKDIR /App
COPY backend .
# Restore as distinct layers
RUN dotnet restore
# Integrate front end
COPY --from=frontend /App/dist/photos/browser ./wwwroot
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=backend /App/out .
ENTRYPOINT ["dotnet", "Photos.dll"]
# Make the web server accessible
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000