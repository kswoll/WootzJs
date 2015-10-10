mkdir .\build.new
copy .\build\placeholder.txt .\build.new
copy .\build\WootzJs.targets .\build.new
del /q .\build\*.*
copy .\build.new\*.* .\build
del /q .\build.new\*.*
rmdir /q /s .\build.new

rmdir /q /s .\WootzJs.Compiler\bin
rmdir /q /s .\WootzJs.Compiler\obj
rmdir /q /s .\WootzJs.Compiler.Tests\bin
rmdir /q /s .\WootzJs.Compiler.Tests\obj
rmdir /q /s .\WootzJs.ComponentModel.DataAnnotations\bin
rmdir /q /s .\WootzJs.ComponentModel.DataAnnotations\obj
rmdir /q /s .\WootzJs.Injection\bin
rmdir /q /s .\WootzJs.Injection\obj
rmdir /q /s .\WootzJs.JQuery\bin
rmdir /q /s .\WootzJs.JQuery\obj
rmdir /q /s .\WootzJs.Models.Js\bin
rmdir /q /s .\WootzJs.Models.Js\obj
rmdir /q /s .\WootzJs.Models.Net45\bin
rmdir /q /s .\WootzJs.Models.net45\obj
rmdir /q /s .\WootzJs.Mvc\bin
rmdir /q /s .\WootzJs.Mvc\obj
rmdir /q /s .\WootzJs.Runtime\bin
rmdir /q /s .\WootzJs.Runtime\obj
rmdir /q /s .\WootzJs.Rx\bin
rmdir /q /s .\WootzJs.Rx\obj
rmdir /q /s .\WootzJs.Rx.Tests\bin
rmdir /q /s .\WootzJs.Rx.Tests\obj
rmdir /q /s .\WootzJs.System\bin
rmdir /q /s .\WootzJs.System\obj
rmdir /q /s .\WootzJs.Web\bin
rmdir /q /s .\WootzJs.Web\obj