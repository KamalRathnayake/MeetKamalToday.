docker build --no-cache -t kamalrathnayake/writer -f 'Writer\Dockerfile' .
# docker run -d -p 80:80 --mount source=imagestorage,target=/app/images kamalrathnayake/writer

docker build --no-cache -t kamalrathnayake/reader -f 'Reader\Dockerfile' .
# docker run -d -p 82:80 --mount source=imagestorage,target=/app/images kamalrathnayake/reader

docker push kamalrathnayake/writer
docker push kamalrathnayake/reader