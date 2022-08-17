docker build --no-cache -t kamalrathnayake/authdemoapp -f 'AuthDemoApp\Dockerfile' .
# docker run -d -p 80:80 kamalrathnayake/authdemoapp
docker push kamalrathnayake/authdemoapp