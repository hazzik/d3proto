@echo off

protogen --proto_path=./ service/exchange/exchange.proto --include_imports -ignore_google_protobuf=true -cls_compliance=false -expand_namespace_directories=true -service_generator_type=GENERIC -output_directory=./csharp

pause
