# Пример реализации token based api с помощью Microsoft.OWIN 

#### 1. Устанавливаем пакеты:

Microsoft.Owin

Microsoft.Owin.Cors

Microsoft.Owin.Host.SystemWeb

Microsoft.Owin.Security

Microsoft.Owin.Security.OAuth

Microsoft.AspNet.Identity.Core

Microsoft.AspNet.Identity.Owin

#### 2. Создаем папку Auth

#### 3. Создаем классы MyAuthProvider,TokenRefreshProvider , Startup( Можно через IDE -> Add -> new Item -> OWIN Startup Class).

#### 4. Получаем токен:
PuId - наш произвольный параметр, который нужно занести в токен
``` curl --location --request POST 'http://localhost:59243/Login' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'username=Test' \
--data-urlencode 'password=Test' \
--data-urlencode 'PuId=1' \
--data-urlencode 'grant_type=password'
```

#### 5. Проверяем токен:

``` curl --location --request POST 'http://localhost:59243/api/Values' \
--header 'Authorization: Bearer BVk6t0xMAXnSxDZIuiXbQEjb82yGRnUliB8hcsSuZDD2H8LEBAcTUlDXGJdrK9AKfAqdYrbBMR0v2uDh5P-XGTAsDPEk-hwmp2jkWMFIuwzm1j8nK8eA8Z4bTYCcGtrLdPqbblBE8EwPsmUxigD2aYPiB48vdH_0YxH_NM9Gn442jcsQd7fGNgCo3hioCHDlfB8ZsRK4NxicCxsVZEhChXG4n4aUmTAbrn186KJD81ZT9u-OEXmd-2DfMT4H5hg7wIxibUFGJu5YbLAmy4KElLyn5Gvd98KD98cC2Z9PBau6KfgDYNKCjd0jnVSiWoEQCmJKLFzVe2t-mPS1dycLzNG3hd4dxWoK3Zsi_-OG0-o'
```
