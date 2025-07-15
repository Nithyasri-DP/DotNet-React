ί
KD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IUserService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface 
IUserService !
{ 
Task 
< 
string 
> 
CreateEmployeeAsync (
(( )
CreateEmployeeDto) :
request; B
)B C
;C D
Task 
< 
UserDto 
? 
> 
GetOwnProfileAsync )
() *
int* -
userId. 4
)4 5
;5 6
Task		 
<		 
List		 
<		 
UserDto		 
>		 
>		  
GetAllEmployeesAsync		 0
(		0 1
)		1 2
;		2 3
Task

 
<

 
UserDto

 
>

 
UpdateEmployeeAsync

 )
(

) *
UpdateEmployeeDto

* ;
	updateDto

< E
)

E F
;

F G
Task 
< 
string 
> #
SoftDeleteEmployeeAsync ,
(, -
int- 0
userId1 7
)7 8
;8 9
Task 
< 
object 
? 
>  
GetEmployeeByIdAsync *
(* +
int+ .
id/ 1
)1 2
;2 3
} 
} Κ
LD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\ITokenService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface 
ITokenService "
{ 
string 
GenerateToken 
( 
User !
user" &
)& '
;' (
} 
}		 η	
UD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IServiceRequestService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface "
IServiceRequestService +
{ 
Task 
< 
bool 
> %
CreateServiceRequestAsync ,
(, -
ServiceRequestDto- >
dto? B
,B C
intD G
userIdH N
)N O
;O P
Task		 
<		 
List		 
<		 
ServiceRequest		  
>		  !
>		! "%
GetMyServiceRequestsAsync		# <
(		< =
int		= @
userId		A G
)		G H
;		H I
Task

 
<

 
List

 
<

 
ServiceRequest

  
>

  !
>

! "&
GetAllServiceRequestsAsync

# =
(

= >
)

> ?
;

? @
Task 
< 
bool 
> +
UpdateServiceRequestStatusAsync 2
(2 3
ServiceUpdateDto3 C
dtoD G
)G H
;H I
} 
} Ξ

OD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\ICategoryService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface 
ICategoryService %
{ 
Task 
< 
List 
< 
CategoryDto 
> 
> !
GetAllCategoriesAsync  5
(5 6
)6 7
;7 8
Task 
< 
CategoryCreateDto 
? 
>   
GetCategoryByIdAsync! 5
(5 6
int6 9
id: <
)< =
;= >
Task		 
<		 
string		 
>		 
CreateCategoryAsync		 (
(		( )
CategoryCreateDto		) :
dto		; >
)		> ?
;		? @
Task

 
<

 
string

 
>

 
UpdateCategoryAsync

 (
(

( )
int

) ,
id

- /
,

/ 0
CategoryCreateDto

1 B
dto

C F
)

F G
;

G H
Task 
< 
string 
> 
DeleteCategoryAsync (
(( )
int) ,
id- /
)/ 0
;0 1
} 
} Έ
KD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IAuthService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface 
IAuthService !
{ 
Task 
< 
string 
> 

LoginAsync 
(  
LoginRequest  ,
request- 4
)4 5
;5 6
Task		 
<		 
string		 
>		 
ForgotPasswordAsync		 (
(		( )
string		) /
email		0 5
)		5 6
;		6 7
Task

 
<

 
string

 
>

 
ResetPasswordAsync

 '
(

' ( 
ResetPasswordRequest

( <
request

= D
)

D E
;

E F
Task 
< 
User 
> 
GetUserByEmailAsync &
(& '
string' -
email. 3
)3 4
;4 5
} 
} Δ	
SD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IAuditRequestService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface  
IAuditRequestService )
{ 
Task 
< 
bool 
> #
CreateAuditRequestAsync *
(* +
int+ .
assignmentId/ ;
); <
;< =
Task		 
<		 
List		 
<		 

AssetAudit		 
>		 
>		 #
GetMyAuditRequestsAsync		 6
(		6 7
int		7 :
userId		; A
)		A B
;		B C
Task

 
<

 
bool

 
>

 
RespondToAuditAsync

 &
(

& '
AuditResponseDto

' 7
dto

8 ;
,

; <
int

= @
userId

A G
)

G H
;

H I
Task 
< 
List 
< 

AssetAudit 
> 
> $
GetAllAuditRequestsAsync 7
(7 8
)8 9
;9 :
} 
} «
LD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IAssetService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #

Interfaces# -
{ 
public 

	interface 
IAssetService "
{ 
Task 
< 
int 
> 
CreateAssetAsync "
(" #
AssetCreateDto# 1
assetDto2 :
): ;
;; <
Task 
< 
IEnumerable 
< 
AssetDetailDto '
>' (
>( )
GetAllAssetsAsync* ;
(; <
)< =
;= >
Task		 
<		 
AssetDetailDto		 
?		 
>		 
GetAssetByIdAsync		 /
(		/ 0
int		0 3
assetId		4 ;
)		; <
;		< =
Task

 
<

 
bool

 
>

 
UpdateAssetAsync

 #
(

# $
int

$ '
assetId

( /
,

/ 0
AssetUpdateDto

1 ?
assetDto

@ H
)

H I
;

I J
Task 
< 
bool 
> 
DeleteAssetAsync #
(# $
int$ '
assetId( /
)/ 0
;0 1
Task 
< 
IEnumerable 
< 
AssetAvailableDto *
>* +
>+ ,.
"GetAvailableAssetsForEmployeeAsync- O
(O P
)P Q
;Q R
Task 
< 
List 
< 
AssetAssignDto  
>  !
>! "-
!GetAssignedAssetsForEmployeeAsync# D
(D E
intE H
userIdI O
)O P
;P Q
} 
} Χ
VD:\VSCodezz\AssetPortal\AssetManagement\Services\Interfaces\IAssetAssignmentService.cs
public 
	interface #
IAssetAssignmentService (
{ 
Task 
< 	
string	 
> 
RequestAssetAsync "
(" #
int# &
userId' -
,- .
AssetRequestDto/ >

requestDto? I
)I J
;J K
Task 
< 	
string	 
> 
AssignAssetAsync !
(! "
AssetAssignInputDto" 5
dto6 9
)9 :
;: ;
Task 
< 	
string	 
> 
RequestReturnAsync #
(# $
int$ '
assignmentId( 4
,4 5
int6 9

employeeId: D
)D E
;E F
Task		 
<		 	
string			 
>		 
ApproveReturnAsync		 #
(		# $
int		$ '
assignmentId		( 4
)		4 5
;		5 6
Task

 
<

 	
List

	 
<

 
AssetAssignDto

 
>

 
>

 &
GetAllPendingRequestsAsync

 9
(

9 :
)

: ;
;

; <
Task 
< 	
List	 
< 
AssetAssignDto 
> 
> %
GetAllReturnRequestsAsync 8
(8 9
)9 :
;: ;
Task 
< 	
string	 
> 
RejectRequestAsync #
(# $
int$ '
assignmentId( 4
)4 5
;5 6
Task 
< 	
string	 
> $
RejectReturnRequestAsync )
() *
int* -
assignmentId. :
): ;
;; <
Task 
< 	
List	 
< 
AssetAssignDto 
> 
> %
GetAllAssignedAssetsAsync 8
(8 9
)9 :
;: ;
Task 
< 	
List	 
< 
AssetAssignDto 
> 
> '
GetAllRejectedRequestsAsync :
(: ;
); <
;< =
Task 
< 	
List	 
< 
AssetAssignDto 
> 
> 
GetMyAssetsAsync /
(/ 0
int0 3
userId4 :
): ;
;; <
} νq
OD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\UserService.cs
	namespace		 	
AssetManagement		
 
.		 
Services		 "
.		" #
Implementations		# 2
{

 
public 

class 
UserService 
: 
IUserService +
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public 
UserService 
(  
ApplicationDbContext /
context0 7
,7 8
IMapper9 @
mapperA G
)G H
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
string  
>  !
CreateEmployeeAsync" 5
(5 6
CreateEmployeeDto6 G
requestH O
)O P
{ 	
if 
( 
await 
_context 
. 
Users $
.$ %
AnyAsync% -
(- .
u. /
=>0 2
u3 4
.4 5
Email5 :
==; =
request> E
.E F
EmailF K
)K L
)L M
throw 
new #
BadHttpRequestException 1
(1 2
$str2 X
)X Y
;Y Z
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
request+ 2
.2 3
PhoneNumber3 >
)> ?
&&@ B
await 
_context 
. 
Users $
.$ %
AnyAsync% -
(- .
u. /
=>0 2
u3 4
.4 5
PhoneNumber5 @
==A C
requestD K
.K L
PhoneNumberL W
)W X
)X Y
throw 
new #
BadHttpRequestException 1
(1 2
$str2 \
)\ ]
;] ^
var 
employee 
= 
_mapper "
." #
Map# &
<& '
User' +
>+ ,
(, -
request- 4
)4 5
;5 6
var!! 
normalizedRole!! 
=!!  
request!!! (
.!!( )
RoleName!!) 1
.!!1 2
Trim!!2 6
(!!6 7
)!!7 8
.!!8 9
ToLower!!9 @
(!!@ A
)!!A B
;!!B C
if## 
(## 
normalizedRole## 
!=## !
$str##" ,
)##, -
throw$$ 
new$$ #
BadHttpRequestException$$ 1
($$1 2
$str$$2 f
)$$f g
;$$g h
var&& 
role&& 
=&& 
await&& 
_context&& %
.&&% &
Roles&&& +
.'' 
FirstOrDefaultAsync'' $
(''$ %
r''% &
=>''' )
r''* +
.''+ ,
RoleName'', 4
.''4 5
ToLower''5 <
(''< =
)''= >
==''? A
normalizedRole''B P
)''P Q
;''Q R
if)) 
()) 
role)) 
==)) 
null)) 
))) 
throw** 
new** #
BadHttpRequestException** 1
(**1 2
$str**2 C
)**C D
;**D E
employee,, 
.,, 
RoleId,, 
=,, 
role,, "
.,," #
RoleId,,# )
;,,) *
employee-- 
.-- 
Password-- 
=-- 
BCrypt--  &
.--& '
Net--' *
.--* +
BCrypt--+ 1
.--1 2
HashPassword--2 >
(--> ?
request--? F
.--F G
Password--G O
!--O P
)--P Q
;--Q R
await// 
_context// 
.// 
Users//  
.//  !
AddAsync//! )
(//) *
employee//* 2
)//2 3
;//3 4
await00 
_context00 
.00 
SaveChangesAsync00 +
(00+ ,
)00, -
;00- .
return22 
$str22 3
;223 4
}33 	
public44 
async44 
Task44 
<44 
UserDto44 !
?44! "
>44" #
GetOwnProfileAsync44$ 6
(446 7
int447 :
userId44; A
)44A B
{55 	
var66 
user66 
=66 
await66 
_context66 %
.66% &
Users66& +
.77 
Include77 
(77 
u77 
=>77 
u77 
.77  
Role77  $
)77$ %
.88 
FirstOrDefaultAsync88 $
(88$ %
u88% &
=>88' )
u88* +
.88+ ,
UserId88, 2
==883 5
userId886 <
)88< =
;88= >
return:: 
user:: 
==:: 
null:: 
?::  !
null::" &
:::' (
_mapper::) 0
.::0 1
Map::1 4
<::4 5
UserDto::5 <
>::< =
(::= >
user::> B
)::B C
;::C D
};; 	
public== 
async== 
Task== 
<== 
List== 
<== 
UserDto== &
>==& '
>==' ( 
GetAllEmployeesAsync==) =
(=== >
)==> ?
{>> 	
var?? 
	employees?? 
=?? 
await?? !
_context??" *
.??* +
Users??+ 0
.@@ 
Include@@ 
(@@ 
u@@ 
=>@@ 
u@@ 
.@@  
Role@@  $
)@@$ %
.AA 
WhereAA 
(AA 
uAA 
=>AA 
!AA 
uAA 
.AA 
	IsDeletedAA (
&&AA) +
uAA, -
.AA- .
RoleAA. 2
.AA2 3
RoleNameAA3 ;
==AA< >
$strAA? I
)AAI J
.BB 
ToListAsyncBB 
(BB 
)BB 
;BB 
returnDD 
_mapperDD 
.DD 
MapDD 
<DD 
ListDD #
<DD# $
UserDtoDD$ +
>DD+ ,
>DD, -
(DD- .
	employeesDD. 7
)DD7 8
;DD8 9
}EE 	
publicFF 
asyncFF 
TaskFF 
<FF 
UserDtoFF !
>FF! "
UpdateEmployeeAsyncFF# 6
(FF6 7
UpdateEmployeeDtoFF7 H
	updateDtoFFI R
)FFR S
{GG 	
varHH 
userHH 
=HH 
awaitHH 
_contextHH %
.HH% &
UsersHH& +
.HH+ ,
IncludeHH, 3
(HH3 4
uHH4 5
=>HH6 8
uHH9 :
.HH: ;
RoleHH; ?
)HH? @
.HH@ A
FirstOrDefaultAsyncHHA T
(HHT U
uHHU V
=>HHW Y
uHHZ [
.HH[ \
UserIdHH\ b
==HHc e
	updateDtoHHf o
.HHo p
UserIdHHp v
)HHv w
;HHw x
ifII 
(II 
userII 
==II 
nullII 
)II 
throwJJ 
newJJ  
KeyNotFoundExceptionJJ .
(JJ. /
$strJJ/ ?
)JJ? @
;JJ@ A
varLL 
normalizedRoleLL 
=LL  
	updateDtoLL! *
.LL* +
RoleNameLL+ 3
.LL3 4
TrimLL4 8
(LL8 9
)LL9 :
.LL: ;
ToLowerLL; B
(LLB C
)LLC D
;LLD E
ifNN 
(NN 
normalizedRoleNN 
!=NN !
$strNN" ,
)NN, -
throwOO 
newOO #
BadHttpRequestExceptionOO 1
(OO1 2
$strOO2 Y
)OOY Z
;OOZ [
varQQ 
roleQQ 
=QQ 
awaitQQ 
_contextQQ %
.QQ% &
RolesQQ& +
.RR 
FirstOrDefaultAsyncRR $
(RR$ %
rRR% &
=>RR' )
rRR* +
.RR+ ,
RoleNameRR, 4
.RR4 5
ToLowerRR5 <
(RR< =
)RR= >
==RR? A
normalizedRoleRRB P
)RRP Q
;RRQ R
ifTT 
(TT 
roleTT 
==TT 
nullTT 
)TT 
throwUU 
newUU  
KeyNotFoundExceptionUU .
(UU. /
$strUU/ @
)UU@ A
;UUA B
ifWW 
(WW 
!WW 
stringWW 
.WW 
IsNullOrWhiteSpaceWW *
(WW* +
	updateDtoWW+ 4
.WW4 5
EmailWW5 :
)WW: ;
)WW; <
{XX 
varYY 
existingEmailYY !
=YY" #
awaitYY$ )
_contextYY* 2
.YY2 3
UsersYY3 8
.ZZ 
AnyAsyncZZ 
(ZZ 
uZZ 
=>ZZ  "
uZZ# $
.ZZ$ %
EmailZZ% *
==ZZ+ -
	updateDtoZZ. 7
.ZZ7 8
EmailZZ8 =
&&ZZ> @
uZZA B
.ZZB C
UserIdZZC I
!=ZZJ L
	updateDtoZZM V
.ZZV W
UserIdZZW ]
&&ZZ^ `
!ZZa b
uZZb c
.ZZc d
	IsDeletedZZd m
)ZZm n
;ZZn o
if\\ 
(\\ 
existingEmail\\ !
)\\! "
throw]] 
new]] %
InvalidOperationException]] 7
(]]7 8
$str]]8 o
)]]o p
;]]p q
}^^ 
if`` 
(`` 
!`` 
string`` 
.`` 
IsNullOrWhiteSpace`` *
(``* +
	updateDto``+ 4
.``4 5
PhoneNumber``5 @
)``@ A
)``A B
{aa 
varbb 
existingPhonebb !
=bb" #
awaitbb$ )
_contextbb* 2
.bb2 3
Usersbb3 8
.cc 
AnyAsynccc 
(cc 
ucc 
=>cc  "
ucc# $
.cc$ %
PhoneNumbercc% 0
==cc1 3
	updateDtocc4 =
.cc= >
PhoneNumbercc> I
&&ccJ L
uccM N
.ccN O
UserIdccO U
!=ccV X
	updateDtoccY b
.ccb c
UserIdccc i
&&ccj l
!ccm n
uccn o
.cco p
	IsDeletedccp y
)ccy z
;ccz {
ifee 
(ee 
existingPhoneee !
)ee! "
throwff 
newff %
InvalidOperationExceptionff 7
(ff7 8
$strff8 v
)ffv w
;ffw x
}gg 
_mapperii 
.ii 
Mapii 
(ii 
	updateDtoii !
,ii! "
userii# '
)ii' (
;ii( )
userjj 
.jj 
RoleIdjj 
=jj 
rolejj 
.jj 
RoleIdjj %
;jj% &
userkk 
.kk 
Rolekk 
=kk 
rolekk 
;kk 
awaitmm 
_contextmm 
.mm 
SaveChangesAsyncmm +
(mm+ ,
)mm, -
;mm- .
returnoo 
_mapperoo 
.oo 
Mapoo 
<oo 
UserDtooo &
>oo& '
(oo' (
useroo( ,
)oo, -
;oo- .
}pp 	
publicqq 
asyncqq 
Taskqq 
<qq 
objectqq  
?qq  !
>qq! " 
GetEmployeeByIdAsyncqq# 7
(qq7 8
intqq8 ;
idqq< >
)qq> ?
{rr 	
varss 
employeess 
=ss 
awaitss  
_contextss! )
.ss) *
Usersss* /
.tt 
Wherett 
(tt 
utt 
=>tt 
utt 
.tt 
UserIdtt $
==tt% '
idtt( *
&&tt+ -
utt. /
.tt/ 0
	IsDeletedtt0 9
==tt: <
falsett= B
)ttB C
.uu 
Selectuu 
(uu 
uuu 
=>uu 
newuu  
{vv 
uww 
.ww 
UserIdww 
,ww 
uxx 
.xx 
FullNamexx 
,xx 
uyy 
.yy 
Emailyy 
,yy 
uzz 
.zz 
PhoneNumberzz !
,zz! "
u{{ 
.{{ 
Address{{ 
,{{ 
Role|| 
=|| 
u|| 
.|| 
Role|| !
.||! "
RoleName||" *
}}} 
)}} 
.~~ 
FirstOrDefaultAsync~~ $
(~~$ %
)~~% &
;~~& '
return
€€ 
employee
€€ 
;
€€ 
}
 	
public
‚‚ 
async
‚‚ 
Task
‚‚ 
<
‚‚ 
string
‚‚  
>
‚‚  !%
SoftDeleteEmployeeAsync
‚‚" 9
(
‚‚9 :
int
‚‚: =
userId
‚‚> D
)
‚‚D E
{
ƒƒ 	
var
„„ 
user
„„ 
=
„„ 
await
„„ 
_context
„„ %
.
„„% &
Users
„„& +
.
„„+ ,!
FirstOrDefaultAsync
„„, ?
(
„„? @
u
„„@ A
=>
„„B D
u
„„E F
.
„„F G
UserId
„„G M
==
„„N P
userId
„„Q W
&&
„„X Z
!
„„[ \
u
„„\ ]
.
„„] ^
	IsDeleted
„„^ g
)
„„g h
;
„„h i
if
…… 
(
…… 
user
…… 
==
…… 
null
…… 
)
…… 
throw
†† 
new
†† "
KeyNotFoundException
†† .
(
††. /
$str
††/ S
)
††S T
;
††T U
user
 
.
 
	IsDeleted
 
=
 
true
 !
;
! "
user
‰‰ 
.
‰‰ 
	DeletedAt
‰‰ 
=
‰‰ 
DateTime
‰‰ %
.
‰‰% &
UtcNow
‰‰& ,
;
‰‰, -
await
‹‹ 
_context
‹‹ 
.
‹‹ 
SaveChangesAsync
‹‹ +
(
‹‹+ ,
)
‹‹, -
;
‹‹- .
return
 
$str
 8
;
8 9
}
 	
}
 
} Ι
PD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\TokenService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #
Implementations# 2
{		 
public

 

class

 
TokenService

 
:

 

Interfaces

  *
.

* +
ITokenService

+ 8
{ 
private 
readonly 
IConfiguration '
_configuration( 6
;6 7
public 
TokenService 
( 
IConfiguration *
configuration+ 8
)8 9
{ 	
_configuration 
= 
configuration *
;* +
} 	
public 
string 
GenerateToken #
(# $
User$ (
user) -
)- .
{ 	
var 

authClaims 
= 
new  
List! %
<% &
Claim& +
>+ ,
{ 
new 
Claim 
( 

ClaimTypes $
.$ %
NameIdentifier% 3
,3 4
user5 9
.9 :
UserId: @
.@ A
ToStringA I
(I J
)J K
)K L
,L M
new 
Claim 
( 

ClaimTypes $
.$ %
Email% *
,* +
user, 0
.0 1
Email1 6
??7 9
string: @
.@ A
EmptyA F
)F G
,G H
new 
Claim 
( 

ClaimTypes $
.$ %
Role% )
,) *
user+ /
./ 0
Role0 4
?4 5
.5 6
RoleName6 >
??? A
stringB H
.H I
EmptyI N
)N O
,O P
new 
Claim 
( 
$str  
,  !
user" &
.& '
FullName' /
??0 2
string3 9
.9 :
Empty: ?
)? @
} 
; 
var 
authSigningKey 
=  
new! $ 
SymmetricSecurityKey% 9
(9 :
Encoding 
. 
UTF8 
. 
GetBytes &
(& '
_configuration' 5
[5 6
$str6 ?
]? @
??A C
$strD Z
)Z [
)[ \
;\ ]
var 
token 
= 
new 
JwtSecurityToken ,
(, -
issuer   
:   
_configuration   &
[  & '
$str  ' 3
]  3 4
,  4 5
audience!! 
:!! 
_configuration!! (
[!!( )
$str!!) 7
]!!7 8
,!!8 9
expires"" 
:"" 
DateTime"" !
.""! "
UtcNow""" (
.""( )

AddMinutes"") 3
(""3 4
Convert## 
.## 
ToDouble## $
(##$ %
_configuration##% 3
[##3 4
$str##4 K
]##K L
??##M O
$str##P T
)##T U
)##U V
,##V W
claims$$ 
:$$ 

authClaims$$ "
,$$" #
signingCredentials%% "
:%%" #
new%%$ '
SigningCredentials%%( :
(%%: ;
authSigningKey%%; I
,%%I J
SecurityAlgorithms%%K ]
.%%] ^

HmacSha256%%^ h
)%%h i
)&& 
;&& 
return(( 
new(( #
JwtSecurityTokenHandler(( .
(((. /
)((/ 0
.((0 1

WriteToken((1 ;
(((; <
token((< A
)((A B
;((B C
})) 	
}** 
}++ Ζ;
YD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\ServiceRequestService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #
Implementations# 2
{ 
public		 

class		 !
ServiceRequestService		 &
:		' ("
IServiceRequestService		) ?
{

 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public !
ServiceRequestService $
($ % 
ApplicationDbContext% 9
context: A
)A B
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
bool 
> %
CreateServiceRequestAsync  9
(9 :
ServiceRequestDto: K
dtoL O
,O P
intQ T
userIdU [
)[ \
{ 	
var 

assignment 
= 
await "
_context# +
.+ ,
AssetAssignments, <
. 
Include 
( 
a 
=> 
a 
.  
Asset  %
)% &
. 
FirstOrDefaultAsync $
($ %
a% &
=>' )
a* +
.+ ,
AssignmentId, 8
==9 ;
dto< ?
.? @
AssignmentId@ L
&&M O
aP Q
.Q R
UserIdR X
==Y [
userId\ b
&&c e
!f g
ag h
.h i

IsReturnedi s
)s t
;t u
if 
( 

assignment 
== 
null "
)" #
return 
false 
; 
var 
existingRequest 
=  !
await" '
_context( 0
.0 1
ServiceRequests1 @
. 
AnyAsync 
( 
r 
=> 
r  
.  !
UserId! '
==( *
userId+ 1
&&2 4
r  
.  !
AssetId! (
==) +

assignment, 6
.6 7
AssetId7 >
&&? A
r  
.  !
Status! '
!=( *
$str+ 6
&&7 9
r  
.  !
Status! '
!=( *
$str+ 5
)5 6
;6 7
if!! 
(!! 
existingRequest!! 
)!!  
throw"" 
new"" 
	Exception"" #
(""# $
$str""$ `
)""` a
;""a b
string$$ 
formattedIssueType$$ %
=$$& '
char$$( ,
.$$, -
ToUpper$$- 4
($$4 5
dto$$5 8
.$$8 9
	IssueType$$9 B
[$$B C
$num$$C D
]$$D E
)$$E F
+$$G H
dto$$I L
.$$L M
	IssueType$$M V
.$$V W
	Substring$$W `
($$` a
$num$$a b
)$$b c
.$$c d
ToLower$$d k
($$k l
)$$l m
;$$m n
var&& 
request&& 
=&& 
new&& 
ServiceRequest&& ,
{'' 
UserId(( 
=(( 
userId(( 
,((  
AssetId)) 
=)) 

assignment)) $
.))$ %
AssetId))% ,
,)), -
RequestDate** 
=** 
DateTime** &
.**& '
Now**' *
,*** +
	IssueType++ 
=++ 
formattedIssueType++ .
,++. /
Description,, 
=,, 
dto,, !
.,,! "
Description,," -
,,,- .
Status-- 
=-- 
$str-- "
}.. 
;.. 
_context00 
.00 
ServiceRequests00 $
.00$ %
Add00% (
(00( )
request00) 0
)000 1
;001 2
await11 
_context11 
.11 
SaveChangesAsync11 +
(11+ ,
)11, -
;11- .
return22 
true22 
;22 
}33 	
public55 
async55 
Task55 
<55 
List55 
<55 
ServiceRequest55 -
>55- .
>55. /%
GetMyServiceRequestsAsync550 I
(55I J
int55J M
userId55N T
)55T U
{66 	
return77 
await77 
_context77 !
.77! "
ServiceRequests77" 1
.88 
Include88 
(88 
sr88 
=>88 
sr88 !
.88! "
Asset88" '
)88' (
.99 
Where99 
(99 
sr99 
=>99 
sr99 
.99  
UserId99  &
==99' )
userId99* 0
)990 1
.:: 
OrderByDescending:: "
(::" #
sr::# %
=>::& (
sr::) +
.::+ ,
RequestDate::, 7
)::7 8
.;; 
ToListAsync;; 
(;; 
);; 
;;; 
}<< 	
public== 
async== 
Task== 
<== 
List== 
<== 
ServiceRequest== -
>==- .
>==. /&
GetAllServiceRequestsAsync==0 J
(==J K
)==K L
{>> 	
return?? 
await?? 
_context?? !
.??! "
ServiceRequests??" 1
.@@ 
Include@@ 
(@@ 
sr@@ 
=>@@ 
sr@@ !
.@@! "
User@@" &
)@@& '
.AA 
IncludeAA 
(AA 
srAA 
=>AA 
srAA !
.AA! "
AssetAA" '
)AA' (
.BB 
OrderByDescendingBB "
(BB" #
srBB# %
=>BB& (
srBB) +
.BB+ ,
RequestDateBB, 7
)BB7 8
.CC 
ToListAsyncCC 
(CC 
)CC 
;CC 
}DD 	
publicFF 
asyncFF 
TaskFF 
<FF 
boolFF 
>FF +
UpdateServiceRequestStatusAsyncFF  ?
(FF? @
ServiceUpdateDtoFF@ P
dtoFFQ T
)FFT U
{GG 	
varHH 
requestHH 
=HH 
awaitHH 
_contextHH  (
.HH( )
ServiceRequestsHH) 8
.HH8 9
	FindAsyncHH9 B
(HHB C
dtoHHC F
.HHF G
ServiceRequestIdHHG W
)HHW X
;HHX Y
ifJJ 
(JJ 
requestJJ 
==JJ 
nullJJ 
)JJ  
returnKK 
falseKK 
;KK 
requestLL 
.LL 
StatusLL 
=LL 
charLL !
.LL! "
ToUpperLL" )
(LL) *
dtoLL* -
.LL- .
StatusLL. 4
[LL4 5
$numLL5 6
]LL6 7
)LL7 8
+LL9 :
dtoLL; >
.LL> ?
StatusLL? E
.LLE F
	SubstringLLF O
(LLO P
$numLLP Q
)LLQ R
.LLR S
ToLowerLLS Z
(LLZ [
)LL[ \
;LL\ ]
awaitNN 
_contextNN 
.NN 
SaveChangesAsyncNN +
(NN+ ,
)NN, -
;NN- .
returnOO 
trueOO 
;OO 
}PP 	
}QQ 
}RR =
SD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\CategoryService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #
Implementations# 2
{		 
public

 

class

 
CategoryService

  
:

! "
ICategoryService

# 3
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public 
CategoryService 
(  
ApplicationDbContext 3
context4 ;
,; <
IMapper= D
mapperE K
)K L
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
List 
< 
CategoryDto *
>* +
>+ ,!
GetAllCategoriesAsync- B
(B C
)C D
{ 	
var 

categories 
= 
await "
_context# +
.+ ,
AssetCategories, ;
.+ ,
Where, 1
(1 2
c2 3
=>4 6
!7 8
c8 9
.9 :
	IsDeleted: C
)C D
.+ ,
ToListAsync, 7
(7 8
)8 9
;9 :
var 
result 
= 

categories #
.# $
Select$ *
(* +
c+ ,
=>- /
new0 3
CategoryDto4 ?
{ 

CategoryId 
= 
c 
. 

CategoryId )
,) *
CategoryName 
= 
c  
.  !
CategoryName! -
} 
) 
. 
ToList 
( 
) 
; 
return   
result   
;   
}!! 	
public"" 
async"" 
Task"" 
<"" 
CategoryCreateDto"" +
?""+ ,
>"", - 
GetCategoryByIdAsync"". B
(""B C
int""C F
id""G I
)""I J
{## 	
var$$ 
category$$ 
=$$ 
await$$  
_context$$! )
.$$) *
AssetCategories$$* 9
.$$9 :
Where$$: ?
($$? @
c$$@ A
=>$$B D
!$$E F
c$$F G
.$$G H
	IsDeleted$$H Q
)$$Q R
.$$R S
FirstOrDefaultAsync$$S f
($$f g
c$$g h
=>$$i k
c$$l m
.$$m n

CategoryId$$n x
==$$y {
id$$| ~
)$$~ 
;	$$ €
return%% 
category%% 
==%% 
null%% #
?%%$ %
null%%& *
:%%+ ,
_mapper%%- 4
.%%4 5
Map%%5 8
<%%8 9
CategoryCreateDto%%9 J
>%%J K
(%%K L
category%%L T
)%%T U
;%%U V
}&& 	
public(( 
async(( 
Task(( 
<(( 
string((  
>((  !
CreateCategoryAsync((" 5
(((5 6
CategoryCreateDto((6 G
dto((H K
)((K L
{)) 	
if** 
(** 
await** 
_context** 
.** 
AssetCategories** .
.**. /
AnyAsync**/ 7
(**7 8
c**8 9
=>**: <
c**= >
.**> ?
CategoryName**? K
==**L N
dto**O R
.**R S
CategoryName**S _
)**_ `
)**` a
throw++ 
new++ %
InvalidOperationException++ 3
(++3 4
$str++4 S
)++S T
;++T U
var-- 
newCategory-- 
=-- 
_mapper-- %
.--% &
Map--& )
<--) *
AssetCategory--* 7
>--7 8
(--8 9
dto--9 <
)--< =
;--= >
await.. 
_context.. 
... 
AssetCategories.. *
...* +
AddAsync..+ 3
(..3 4
newCategory..4 ?
)..? @
;..@ A
await// 
_context// 
.// 
SaveChangesAsync// +
(//+ ,
)//, -
;//- .
return11 
$str11 3
;113 4
}22 	
public33 
async33 
Task33 
<33 
string33  
>33  !
UpdateCategoryAsync33" 5
(335 6
int336 9
id33: <
,33< =
CategoryCreateDto33> O
dto33P S
)33S T
{44 	
var55 
category55 
=55 
await55  
_context55! )
.55) *
AssetCategories55* 9
.559 :
	FindAsync55: C
(55C D
id55D F
)55F G
;55G H
if66 
(66 
category66 
==66 
null66  
)66  !
throw77 
new77  
KeyNotFoundException77 .
(77. /
$str77/ D
)77D E
;77E F
var99 
duplicateExists99 
=99  !
await99" '
_context99( 0
.990 1
AssetCategories991 @
.:: 
AnyAsync:: 
(:: 
c:: 
=>:: 
c::  
.::  !
CategoryName::! -
==::. 0
dto::1 4
.::4 5
CategoryName::5 A
&&::B D
c::E F
.::F G

CategoryId::G Q
!=::R T
id::U W
&&::X Z
!::[ \
c::\ ]
.::] ^
	IsDeleted::^ g
)::g h
;::h i
if<< 
(<< 
duplicateExists<< 
)<<  
throw== 
new== %
InvalidOperationException== 3
(==3 4
$str==4 i
)==i j
;==j k
category?? 
.?? 
CategoryName?? !
=??" #
dto??$ '
.??' (
CategoryName??( 4
;??4 5
_context@@ 
.@@ 
AssetCategories@@ $
.@@$ %
Update@@% +
(@@+ ,
category@@, 4
)@@4 5
;@@5 6
awaitAA 
_contextAA 
.AA 
SaveChangesAsyncAA +
(AA+ ,
)AA, -
;AA- .
returnCC 
$strCC 3
;CC3 4
}DD 	
publicEE 
asyncEE 
TaskEE 
<EE 
stringEE  
>EE  !
DeleteCategoryAsyncEE" 5
(EE5 6
intEE6 9
idEE: <
)EE< =
{FF 	
varGG 
categoryGG 
=GG 
awaitGG  
_contextGG! )
.GG) *
AssetCategoriesGG* 9
.GG9 :
	FindAsyncGG: C
(GGC D
idGGD F
)GGF G
;GGG H
ifHH 
(HH 
categoryHH 
==HH 
nullHH  
)HH  !
throwII 
newII  
KeyNotFoundExceptionII .
(II. /
$strII/ D
)IID E
;IIE F
categoryKK 
.KK 
	IsDeletedKK 
=KK  
trueKK! %
;KK% &
categoryLL 
.LL 
	DeletedAtLL 
=LL  
DateTimeLL! )
.LL) *
UtcNowLL* 0
;LL0 1
awaitMM 
_contextMM 
.MM 
SaveChangesAsyncMM +
(MM+ ,
)MM, -
;MM- .
returnOO 
$strOO 3
;OO3 4
}PP 	
}QQ 
}RR §9
OD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\AuthService.cs
	namespace		 	
AssetManagement		
 
.		 
Services		 "
.		" #
Implementations		# 2
{

 
public 

class 
AuthService 
: 
IAuthService +
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
ITokenService &
_tokenService' 4
;4 5
public 
AuthService 
(  
ApplicationDbContext /
context0 7
,7 8
ITokenService9 F
tokenServiceG S
)S T
{ 	
_context 
= 
context 
; 
_tokenService 
= 
tokenService (
;( )
} 	
public 
async 
Task 
< 
string  
>  !

LoginAsync" ,
(, -
LoginRequest- 9
request: A
)A B
{ 	
if 
( 
string 
. 
IsNullOrWhiteSpace )
() *
request* 1
.1 2
Email2 7
)7 8
||9 ;
string< B
.B C
IsNullOrWhiteSpaceC U
(U V
requestV ]
.] ^
Password^ f
)f g
)g h
throw 
new #
BadHttpRequestException 1
(1 2
$str2 X
)X Y
;Y Z
var 
user 
= 
await 
_context %
.% &
Users& +
. 
Include 
( 
u 
=> 
u 
.  
Role  $
)$ %
. 
FirstOrDefaultAsync $
($ %
u% &
=>' )
u* +
.+ ,
Email, 1
==2 4
request5 <
.< =
Email= B
)B C
;C D
if 
( 
user 
== 
null 
) 
throw 
new '
UnauthorizedAccessException 5
(5 6
$str6 W
)W X
;X Y
bool"" 
isValidPassword""  
=""! "
BCrypt""# )
."") *
Net""* -
.""- .
BCrypt"". 4
.""4 5
Verify""5 ;
(""; <
request""< C
.""C D
Password""D L
,""L M
user""N R
.""R S
Password""S [
)""[ \
;""\ ]
if## 
(## 
!## 
isValidPassword##  
)##  !
throw$$ 
new$$ '
UnauthorizedAccessException$$ 5
($$5 6
$str$$6 h
)$$h i
;$$i j
return&& 
_tokenService&&  
.&&  !
GenerateToken&&! .
(&&. /
user&&/ 3
)&&3 4
;&&4 5
}'' 	
public)) 
async)) 
Task)) 
<)) 
string))  
>))  !
ForgotPasswordAsync))" 5
())5 6
string))6 <
email))= B
)))B C
{** 	
var++ 
user++ 
=++ 
await++ 
_context++ %
.++% &
Users++& +
.+++ ,
FirstOrDefaultAsync++, ?
(++? @
u++@ A
=>++B D
u++E F
.++F G
Email++G L
==++M O
email++P U
)++U V
;++V W
if,, 
(,, 
user,, 
==,, 
null,, 
||,, 
user,,  $
.,,$ %
	IsDeleted,,% .
),,. /
throw-- 
new--  
KeyNotFoundException-- .
(--. /
$str--/ @
)--@ A
;--A B
user// 
.// 

ResetToken// 
=// 
Guid// "
.//" #
NewGuid//# *
(//* +
)//+ ,
.//, -
ToString//- 5
(//5 6
)//6 7
;//7 8
user00 
.00 
ResetTokenExpiry00 !
=00" #
DateTime00$ ,
.00, -
UtcNow00- 3
.003 4

AddMinutes004 >
(00> ?
$num00? A
)00A B
;00B C
await11 
_context11 
.11 
SaveChangesAsync11 +
(11+ ,
)11, -
;11- .
return22 
user22 
.22 

ResetToken22 "
!22" #
;22# $
}33 	
public55 
async55 
Task55 
<55 
string55  
>55  !
ResetPasswordAsync55" 4
(554 5 
ResetPasswordRequest555 I
request55J Q
)55Q R
{66 	
var77 
user77 
=77 
await77 
_context77 %
.77% &
Users77& +
.77+ ,
FirstOrDefaultAsync77, ?
(77? @
u77@ A
=>77B D
u88 
.88 
Email88 
==88 
request88 "
.88" #
Email88# (
&&88) +
u99 
.99 

ResetToken99 
==99 
request99  '
.99' (
Token99( -
&&99. 0
u:: 
.:: 
ResetTokenExpiry:: "
>::# $
DateTime::% -
.::- .
UtcNow::. 4
)::4 5
;::5 6
if<< 
(<< 
user<< 
==<< 
null<< 
)<< 
throw== 
new== '
UnauthorizedAccessException== 5
(==5 6
$str==6 W
)==W X
;==X Y
user?? 
.?? 
Password?? 
=?? 
BCrypt?? "
.??" #
Net??# &
.??& '
BCrypt??' -
.??- .
HashPassword??. :
(??: ;
request??; B
.??B C
NewPassword??C N
)??N O
;??O P
user@@ 
.@@ 

ResetToken@@ 
=@@ 
null@@ "
;@@" #
userAA 
.AA 
ResetTokenExpiryAA !
=AA" #
nullAA$ (
;AA( )
awaitCC 
_contextCC 
.CC 
SaveChangesAsyncCC +
(CC+ ,
)CC, -
;CC- .
returnDD 
$strDD /
;DD/ 0
}EE 	
publicFF 
asyncFF 
TaskFF 
<FF 
UserFF 
>FF 
GetUserByEmailAsyncFF  3
(FF3 4
stringFF4 :
emailFF; @
)FF@ A
{GG 	
returnHH 
awaitHH 
_contextHH !
.HH! "
UsersHH" '
.HH' (
IncludeHH( /
(HH/ 0
uHH0 1
=>HH2 4
uHH5 6
.HH6 7
RoleHH7 ;
)HH; <
.HH< =

FirstAsyncHH= G
(HHG H
uHHH I
=>HHJ L
uHHM N
.HHN O
EmailHHO T
==HHU W
emailHHX ]
)HH] ^
;HH^ _
}II 	
}JJ 
}KK ƒC
WD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\AuditRequestService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #
Implementations# 2
{ 
public		 

class		 
AuditRequestService		 $
:		% & 
IAuditRequestService		' ;
{

 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
public 
AuditRequestService "
(" # 
ApplicationDbContext# 7
context8 ?
)? @
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
bool 
> #
CreateAuditRequestAsync  7
(7 8
int8 ;
assignmentId< H
)H I
{ 	
try 
{ 
var 

assignment 
=  
await! &
_context' /
./ 0
AssetAssignments0 @
. 
Include 
( 
a 
=> !
a" #
.# $
Asset$ )
)) *
. 
Include 
( 
a 
=> !
a" #
.# $
User$ (
)( )
. 
FirstOrDefaultAsync (
(( )
a) *
=>+ -
a. /
./ 0
AssignmentId0 <
=== ?
assignmentId@ L
&&M O
!P Q
aQ R
.R S

IsReturnedS ]
)] ^
;^ _
if 
( 

assignment 
== !
null" &
)& '
return 
false  
;  !
var 
alreadyRequested $
=% &
await' ,
_context- 5
.5 6
AssetAudits6 A
.A B
AnyAsyncB J
(J K
aK L
=>M O
a 
. 
UserId 
== 

assignment  *
.* +
UserId+ 1
&&2 4
a 
. 
AssetId 
==  

assignment! +
.+ ,
AssetId, 3
&&4 6
a   
.   
Status   
.   
ToLower   $
(  $ %
)  % &
==  ' )
$str  * 3
)  3 4
;  4 5
if"" 
("" 
alreadyRequested"" $
)""$ %
return## 
false##  
;##  !
var%% 
audit%% 
=%% 
new%% 

AssetAudit%%  *
{&& 
UserId'' 
='' 

assignment'' '
.''' (
UserId''( .
,''. /
AssetId(( 
=(( 

assignment(( (
.((( )
AssetId(() 0
,((0 1
AuditRequestDate)) $
=))% &
DateTime))' /
.))/ 0
Now))0 3
,))3 4
Status** 
=** 
$str** &
,**& '
Remarks++ 
=++ 
string++ $
.++$ %
Empty++% *
},, 
;,, 
_context.. 
... 
AssetAudits.. $
...$ %
Add..% (
(..( )
audit..) .
)... /
;../ 0
await// 
_context// 
.// 
SaveChangesAsync// /
(/// 0
)//0 1
;//1 2
return00 
true00 
;00 
}11 
catch22 
(22 
	Exception22 
)22 
{33 
return44 
false44 
;44 
}55 
}66 	
public88 
async88 
Task88 
<88 
List88 
<88 

AssetAudit88 )
>88) *
>88* +#
GetMyAuditRequestsAsync88, C
(88C D
int88D G
userId88H N
)88N O
{99 	
try:: 
{;; 
return<< 
await<< 
_context<< %
.<<% &
AssetAudits<<& 1
.== 
Include== 
(== 
a== 
=>== !
a==" #
.==# $
Asset==$ )
)==) *
.>> 
Where>> 
(>> 
a>> 
=>>> 
a>>  !
.>>! "
UserId>>" (
==>>) +
userId>>, 2
)>>2 3
.?? 
OrderByDescending?? &
(??& '
a??' (
=>??) +
a??, -
.??- .
AuditRequestDate??. >
)??> ?
.@@ 
ToListAsync@@  
(@@  !
)@@! "
;@@" #
}AA 
catchBB 
(BB 
	ExceptionBB 
)BB 
{CC 
returnDD 
newDD 
ListDD 
<DD  

AssetAuditDD  *
>DD* +
(DD+ ,
)DD, -
;DD- .
}EE 
}FF 	
publicHH 
asyncHH 
TaskHH 
<HH 
boolHH 
>HH 
RespondToAuditAsyncHH  3
(HH3 4
AuditResponseDtoHH4 D
dtoHHE H
,HHH I
intHHJ M
userIdHHN T
)HHT U
{II 	
tryJJ 
{KK 
varLL 
auditLL 
=LL 
awaitLL !
_contextLL" *
.LL* +
AssetAuditsLL+ 6
.MM 
FirstOrDefaultAsyncMM (
(MM( )
aMM) *
=>MM+ -
aMM. /
.MM/ 0
AuditIdMM0 7
==MM8 :
dtoMM; >
.MM> ?
AuditIdMM? F
&&MMG I
aMMJ K
.MMK L
UserIdMML R
==MMS U
userIdMMV \
)MM\ ]
;MM] ^
ifOO 
(OO 
auditOO 
==OO 
nullOO !
||OO" $
auditOO% *
.OO* +
StatusOO+ 1
.OO1 2
ToLowerOO2 9
(OO9 :
)OO: ;
!=OO< >
$strOO? H
)OOH I
returnPP 
falsePP  
;PP  !
auditRR 
.RR 
StatusRR 
=RR 
dtoRR "
.RR" #
StatusRR# )
.RR) *
ToLowerRR* 1
(RR1 2
)RR2 3
;RR3 4
auditSS 
.SS 
RemarksSS 
=SS 
dtoSS  #
.SS# $
RemarksSS$ +
??SS, .
stringSS/ 5
.SS5 6
EmptySS6 ;
;SS; <
auditTT 
.TT 
AuditResponseDateTT '
=TT( )
DateTimeTT* 2
.TT2 3
NowTT3 6
;TT6 7
awaitVV 
_contextVV 
.VV 
SaveChangesAsyncVV /
(VV/ 0
)VV0 1
;VV1 2
returnWW 
trueWW 
;WW 
}XX 
catchYY 
(YY 
	ExceptionYY 
)YY 
{ZZ 
return[[ 
false[[ 
;[[ 
}\\ 
}]] 	
public^^ 
async^^ 
Task^^ 
<^^ 
List^^ 
<^^ 

AssetAudit^^ )
>^^) *
>^^* +$
GetAllAuditRequestsAsync^^, D
(^^D E
)^^E F
{__ 	
try`` 
{aa 
returnbb 
awaitbb 
_contextbb %
.bb% &
AssetAuditsbb& 1
.cc 
Includecc 
(cc 
acc 
=>cc !
acc" #
.cc# $
Usercc$ (
)cc( )
.dd 
Includedd 
(dd 
add 
=>dd !
add" #
.dd# $
Assetdd$ )
)dd) *
.ee 
ThenIncludeee $
(ee$ %
assetee% *
=>ee+ -
assetee. 3
.ee3 4
AssetCategoryee4 A
)eeA B
.ff 
OrderByDescendingff &
(ff& '
aff' (
=>ff) +
aff, -
.ff- .
AuditRequestDateff. >
)ff> ?
.gg 
ToListAsyncgg  
(gg  !
)gg! "
;gg" #
}hh 
catchii 
(ii 
	Exceptionii 
)ii 
{jj 
returnkk 
newkk 
Listkk 
<kk  

AssetAuditkk  *
>kk* +
(kk+ ,
)kk, -
;kk- .
}ll 
}mm 	
}nn 
}oo ª‡
PD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\AssetService.cs
	namespace 	
AssetManagement
 
. 
Services "
." #
Implementations# 2
{		 
public

 

class

 
AssetService

 
:

 
IAssetService

  -
{ 
private 
readonly  
ApplicationDbContext -
_context. 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public 
AssetService 
(  
ApplicationDbContext 0
context1 8
,8 9
IMapper: A
mapperB H
)H I
{ 	
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 	
public 
async 
Task 
< 
int 
> 
CreateAssetAsync /
(/ 0
AssetCreateDto0 >
assetDto? G
)G H
{ 	
bool 

nameExists 
= 
await #
_context$ ,
., -
Assets- 3
. 
AnyAsync 
( 
a 
=> 
!  
a  !
.! "
	IsDeleted" +
&&, .
a/ 0
.0 1
	AssetName1 :
.: ;
ToLower; B
(B C
)C D
==E G
assetDtoH P
.P Q
	AssetNameQ Z
.Z [
ToLower[ b
(b c
)c d
)d e
;e f
if 
( 

nameExists 
) 
throw 
new %
InvalidOperationException 3
(3 4
$str4 ^
)^ _
;_ `
if 
( 
assetDto 
. 
ManufacturingDate *
.* +
Year+ /
<0 1
$num2 6
)6 7
throw 
new 
ArgumentException +
(+ ,
$str, ]
)] ^
;^ _
if   
(   
assetDto   
.   
ManufacturingDate   *
>  + ,
DateTime  - 5
.  5 6
UtcNow  6 <
)  < =
throw!! 
new!! 
ArgumentException!! +
(!!+ ,
$str!!, Y
)!!Y Z
;!!Z [
if## 
(## 
assetDto## 
.## 

ExpiryDate## #
<=##$ &
DateTime##' /
.##/ 0
UtcNow##0 6
)##6 7
throw$$ 
new$$ 
ArgumentException$$ +
($$+ ,
$str$$, P
)$$P Q
;$$Q R
var&& 
asset&& 
=&& 
_mapper&& 
.&&  
Map&&  #
<&&# $
Asset&&$ )
>&&) *
(&&* +
assetDto&&+ 3
)&&3 4
;&&4 5
await'' 
_context'' 
.'' 
Assets'' !
.''! "
AddAsync''" *
(''* +
asset''+ 0
)''0 1
;''1 2
await(( 
_context(( 
.(( 
SaveChangesAsync(( +
(((+ ,
)((, -
;((- .
return)) 
asset)) 
.)) 
AssetId))  
;))  !
}** 	
public,, 
async,, 
Task,, 
<,, 
bool,, 
>,, 
UpdateAssetAsync,,  0
(,,0 1
int,,1 4
assetId,,5 <
,,,< =
AssetUpdateDto,,> L
dto,,M P
),,P Q
{-- 	
var.. 
asset.. 
=.. 
await.. 
_context.. &
...& '
Assets..' -
...- .
FirstOrDefaultAsync... A
(..A B
a..B C
=>..D F
a..G H
...H I
AssetId..I P
==..Q S
assetId..T [
&&..\ ^
!.._ `
a..` a
...a b
	IsDeleted..b k
)..k l
;..l m
if// 
(// 
asset// 
==// 
null// 
)// 
return// %
false//& +
;//+ ,
if11 
(11 
!11 
string11 
.11 
IsNullOrWhiteSpace11 *
(11* +
dto11+ .
.11. /
	AssetName11/ 8
)118 9
)119 :
{22 
bool33 

nameExists33 
=33  !
await33" '
_context33( 0
.330 1
Assets331 7
.44 
AnyAsync44 
(44 
a44 
=>44  "
a44# $
.44$ %
AssetId44% ,
!=44- /
assetId440 7
&&448 :
!44; <
a44< =
.44= >
	IsDeleted44> G
&&44H J
a44K L
.44L M
	AssetName44M V
.44V W
ToLower44W ^
(44^ _
)44_ `
==44a c
dto44d g
.44g h
	AssetName44h q
.44q r
ToLower44r y
(44y z
)44z {
)44{ |
;44| }
if66 
(66 

nameExists66 
)66 
throw77 
new77 %
InvalidOperationException77 7
(777 8
$str778 j
)77j k
;77k l
asset99 
.99 
	AssetName99 
=99  !
dto99" %
.99% &
	AssetName99& /
;99/ 0
}:: 
if<< 
(<< 
!<< 
string<< 
.<< 
IsNullOrWhiteSpace<< *
(<<* +
dto<<+ .
.<<. /

AssetModel<</ 9
)<<9 :
)<<: ;
asset== 
.== 

AssetModel==  
===! "
dto==# &
.==& '

AssetModel==' 1
;==1 2
if?? 
(?? 
dto?? 
.?? 

CategoryId?? 
.?? 
HasValue?? '
)??' (
asset@@ 
.@@ 

CategoryId@@  
=@@! "
dto@@# &
.@@& '

CategoryId@@' 1
.@@1 2
Value@@2 7
;@@7 8
ifBB 
(BB 
dtoBB 
.BB 
ManufacturingDateBB %
.BB% &
HasValueBB& .
)BB. /
{CC 
ifDD 
(DD 
dtoDD 
.DD 
ManufacturingDateDD )
.DD) *
ValueDD* /
.DD/ 0
YearDD0 4
<DD5 6
$numDD7 ;
)DD; <
throwEE 
newEE 
ArgumentExceptionEE /
(EE/ 0
$strEE0 a
)EEa b
;EEb c
ifGG 
(GG 
dtoGG 
.GG 
ManufacturingDateGG )
.GG) *
ValueGG* /
>GG0 1
DateTimeGG2 :
.GG: ;
UtcNowGG; A
)GGA B
throwHH 
newHH 
ArgumentExceptionHH /
(HH/ 0
$strHH0 ]
)HH] ^
;HH^ _
assetJJ 
.JJ 
ManufacturingDateJJ '
=JJ( )
dtoJJ* -
.JJ- .
ManufacturingDateJJ. ?
.JJ? @
ValueJJ@ E
;JJE F
}KK 
ifMM 
(MM 
dtoMM 
.MM 

ExpiryDateMM 
.MM 
HasValueMM '
)MM' (
{NN 
ifOO 
(OO 
dtoOO 
.OO 

ExpiryDateOO "
.OO" #
ValueOO# (
<=OO) +
DateTimeOO, 4
.OO4 5
UtcNowOO5 ;
)OO; <
throwPP 
newPP 
ArgumentExceptionPP /
(PP/ 0
$strPP0 T
)PPT U
;PPU V
assetRR 
.RR 

ExpiryDateRR  
=RR! "
dtoRR# &
.RR& '

ExpiryDateRR' 1
.RR1 2
ValueRR2 7
;RR7 8
}SS 
ifUU 
(UU 
dtoUU 
.UU 

AssetValueUU 
.UU 
HasValueUU '
)UU' (
assetVV 
.VV 

AssetValueVV  
=VV! "
dtoVV# &
.VV& '

AssetValueVV' 1
.VV1 2
ValueVV2 7
;VV7 8
ifXX 
(XX 
dtoXX 
.XX 
QuantityXX 
.XX 
HasValueXX %
)XX% &
assetYY 
.YY 
QuantityYY 
=YY  
dtoYY! $
.YY$ %
QuantityYY% -
.YY- .
ValueYY. 3
;YY3 4
if[[ 
([[ 
![[ 
string[[ 
.[[ 
IsNullOrWhiteSpace[[ *
([[* +
dto[[+ .
.[[. /
ImageUrl[[/ 7
)[[7 8
)[[8 9
asset\\ 
.\\ 
ImageUrl\\ 
=\\  
dto\\! $
.\\$ %
ImageUrl\\% -
;\\- .
await^^ 
_context^^ 
.^^ 
SaveChangesAsync^^ +
(^^+ ,
)^^, -
;^^- .
return__ 
true__ 
;__ 
}`` 	
publicbb 
asyncbb 
Taskbb 
<bb 
IEnumerablebb %
<bb% &
AssetDetailDtobb& 4
>bb4 5
>bb5 6
GetAllAssetsAsyncbb7 H
(bbH I
)bbI J
{cc 	
vardd 
assetsdd 
=dd 
awaitdd 
_contextdd '
.dd' (
Assetsdd( .
.ee 
Whereee 
(ee 
aee 
=>ee 
!ee 
aee 
.ee 
	IsDeletedee (
)ee( )
.ff 
Includeff 
(ff 
aff 
=>ff 
aff 
.ff  
AssetCategoryff  -
)ff- .
.gg 
ToListAsyncgg 
(gg 
)gg 
;gg 
returnii 
_mapperii 
.ii 
Mapii 
<ii 
IEnumerableii *
<ii* +
AssetDetailDtoii+ 9
>ii9 :
>ii: ;
(ii; <
assetsii< B
)iiB C
;iiC D
}jj 	
publicll 
asyncll 
Taskll 
<ll 
AssetDetailDtoll (
?ll( )
>ll) *
GetAssetByIdAsyncll+ <
(ll< =
intll= @
assetIdllA H
)llH I
{mm 	
varnn 
assetnn 
=nn 
awaitnn 
_contextnn &
.nn& '
Assetsnn' -
.oo 
Whereoo 
(oo 
aoo 
=>oo 
!oo 
aoo 
.oo 
	IsDeletedoo (
)oo( )
.pp 
Includepp 
(pp 
app 
=>pp 
app 
.pp  
AssetCategorypp  -
)pp- .
.qq 
FirstOrDefaultAsyncqq $
(qq$ %
aqq% &
=>qq' )
aqq* +
.qq+ ,
AssetIdqq, 3
==qq4 6
assetIdqq7 >
)qq> ?
;qq? @
returnss 
assetss 
isss 
nullss  
?ss! "
nullss# '
:ss( )
_mapperss* 1
.ss1 2
Mapss2 5
<ss5 6
AssetDetailDtoss6 D
>ssD E
(ssE F
assetssF K
)ssK L
;ssL M
}tt 	
publicvv 
asyncvv 
Taskvv 
<vv 
IEnumerablevv %
<vv% &
AssetAvailableDtovv& 7
>vv7 8
>vv8 9.
"GetAvailableAssetsForEmployeeAsyncvv: \
(vv\ ]
)vv] ^
{ww 	
varxx 
assetsxx 
=xx 
awaitxx 
_contextxx '
.xx' (
Assetsxx( .
.yy 
Includeyy 
(yy 
ayy 
=>yy 
ayy 
.yy  
AssetCategoryyy  -
)yy- .
.zz 
Wherezz 
(zz 
azz 
=>zz 
!zz 
azz 
.zz 
	IsDeletedzz (
&&zz) +
azz, -
.zz- .
Quantityzz. 6
>zz7 8
$numzz9 :
)zz: ;
.{{ 
ToListAsync{{ 
({{ 
){{ 
;{{ 
return}} 
_mapper}} 
.}} 
Map}} 
<}} 
IEnumerable}} *
<}}* +
AssetAvailableDto}}+ <
>}}< =
>}}= >
(}}> ?
assets}}? E
)}}E F
;}}F G
}~~ 	
public
€€ 
async
€€ 
Task
€€ 
<
€€ 
bool
€€ 
>
€€ 
DeleteAssetAsync
€€  0
(
€€0 1
int
€€1 4
assetId
€€5 <
)
€€< =
{
 	
var
‚‚ 
asset
‚‚ 
=
‚‚ 
await
‚‚ 
_context
‚‚ &
.
‚‚& '
Assets
‚‚' -
.
‚‚- .
	FindAsync
‚‚. 7
(
‚‚7 8
assetId
‚‚8 ?
)
‚‚? @
;
‚‚@ A
if
ƒƒ 
(
ƒƒ 
asset
ƒƒ 
==
ƒƒ 
null
ƒƒ 
||
ƒƒ  
asset
ƒƒ! &
.
ƒƒ& '
	IsDeleted
ƒƒ' 0
)
ƒƒ0 1
return
ƒƒ2 8
false
ƒƒ9 >
;
ƒƒ> ?
asset
…… 
.
…… 
	IsDeleted
…… 
=
…… 
true
…… "
;
……" #
asset
†† 
.
†† 
	DeletedAt
†† 
=
†† 
DateTime
†† &
.
††& '
UtcNow
††' -
;
††- .
await
‡‡ 
_context
‡‡ 
.
‡‡ 
SaveChangesAsync
‡‡ +
(
‡‡+ ,
)
‡‡, -
;
‡‡- .
return
 
true
 
;
 
}
‰‰ 	
public
 
async
 
Task
 
<
 
List
 
<
 
AssetAssignDto
 -
>
- .
>
. //
!GetAssignedAssetsForEmployeeAsync
0 Q
(
Q R
int
R U
userId
V \
)
\ ]
{
‹‹ 	
var
 
assignments
 
=
 
await
 #
_context
$ ,
.
, -
AssetAssignments
- =
.
 
Include
 
(
 
a
 
=>
 
a
 
.
  
Asset
  %
)
% &
.
& '
ThenInclude
' 2
(
2 3
a
3 4
=>
5 7
a
8 9
.
9 :
AssetCategory
: G
)
G H
.
 
Include
 
(
 
a
 
=>
 
a
 
.
  
User
  $
)
$ %
.
 
Where
 
(
 
a
 
=>
 
a
 
.
 
UserId
 $
==
% '
userId
( .
&&
/ 1
a
2 3
.
3 4
Status
4 :
==
; =
$str
> H
)
H I
.
 
ToListAsync
 
(
 
)
 
;
 
return
’’ 
assignments
’’ 
.
’’ 
Select
’’ %
(
’’% &
a
’’& '
=>
’’( *
new
’’+ .
AssetAssignDto
’’/ =
{
““ 
AssignmentId
”” 
=
”” 
a
””  
.
””  !
AssignmentId
””! -
,
””- .
UserId
•• 
=
•• 
a
•• 
.
•• 
UserId
•• !
,
••! "
UserName
–– 
=
–– 
a
–– 
.
–– 
User
–– !
.
––! "
FullName
––" *
,
––* +
AssetId
—— 
=
—— 
a
—— 
.
—— 
AssetId
—— #
,
——# $
	AssetName
 
=
 
a
 
.
 
Asset
 #
.
# $
	AssetName
$ -
,
- .

AssetModel
™™ 
=
™™ 
a
™™ 
.
™™ 
Asset
™™ $
.
™™$ %

AssetModel
™™% /
,
™™/ 0
CategoryName
 
=
 
a
  
.
  !
Asset
! &
.
& '
AssetCategory
' 4
.
4 5
CategoryName
5 A
,
A B
ImageUrl
›› 
=
›› 
a
›› 
.
›› 
Asset
›› "
.
››" #
ImageUrl
››# +
,
››+ ,
Quantity
 
=
 
a
 
.
 
Quantity
 %
,
% &
Status
 
=
 
a
 
.
 
Status
 !
,
! "
AssignedDate
 
=
 
a
  
.
  !
AssignedDate
! -
,
- .

ReturnDate
 
=
 
a
 
.
 

ReturnDate
 )
}
   
)
   
.
   
ToList
   
(
   
)
   
;
   
}
΅΅ 	
}
ΆΆ 
}££ ±Α
ZD:\VSCodezz\AssetPortal\AssetManagement\Services\Implementations\AssetAssignmentService.cs
public		 
class		 "
AssetAssignmentService		 #
:		$ %#
IAssetAssignmentService		& =
{

 
private 
readonly  
ApplicationDbContext )
_context* 2
;2 3
private 
readonly 
IMapper 
_mapper $
;$ %
public 
"
AssetAssignmentService !
(! " 
ApplicationDbContext" 6
context7 >
,> ?
IMapper@ G
mapperH N
)N O
{ 
_context 
= 
context 
; 
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
string 
> 
RequestAssetAsync /
(/ 0
int0 3
userId4 :
,: ;
AssetRequestDto< K

requestDtoL V
)V W
{ 
var 
asset 
= 
await 
_context "
." #
Assets# )
.) *
FirstOrDefaultAsync* =
(= >
a> ?
=>@ B
aC D
.D E
AssetIdE L
==M O

requestDtoP Z
.Z [
AssetId[ b
&&c e
!f g
ag h
.h i
	IsDeletedi r
)r s
;s t
if 

( 
asset 
== 
null 
) 
throw 
new 
	Exception 
(  
$str  2
)2 3
;3 4
var "
existingPendingRequest "
=# $
await% *
_context+ 3
.3 4
AssetAssignments4 D
. 
AnyAsync 
( 
a 
=> 
a 
. 
UserId #
==$ &
userId' -
&&. 0
a1 2
.2 3
AssetId3 :
==; =

requestDto> H
.H I
AssetIdI P
&&Q S
aT U
.U V
StatusV \
==] _
$str` k
)k l
;l m
if 

( "
existingPendingRequest "
)" #
throw 
new 
	Exception 
(  
$str  b
)b c
;c d
var 
alreadyAssigned 
= 
await #
_context$ ,
., -
AssetAssignments- =
.   
AnyAsync   
(   
a   
=>   
a   
.   
UserId   #
==  $ &
userId  ' -
&&  . 0
a  1 2
.  2 3
AssetId  3 :
==  ; =

requestDto  > H
.  H I
AssetId  I P
&&  Q S
a  T U
.  U V
Status  V \
==  ] _
$str  ` j
)  j k
;  k l
if"" 

("" 
alreadyAssigned"" 
)"" 
throw## 
new## 
	Exception## 
(##  
$str##  G
)##G H
;##H I
if%% 

(%% 

requestDto%% 
.%% 
Quantity%% 
<=%%  "
$num%%# $
)%%$ %
throw&& 
new&& 
	Exception&& 
(&&  
$str&&  E
)&&E F
;&&F G
var(( 

assignment(( 
=(( 
new(( 
AssetAssignment(( ,
{)) 	
UserId** 
=** 
userId** 
,** 
AssetId++ 
=++ 

requestDto++  
.++  !
AssetId++! (
,++( )
Quantity,, 
=,, 

requestDto,, !
.,,! "
Quantity,," *
,,,* +
Status-- 
=-- 
$str--  
,--  !
AssignedDate.. 
=.. 
DateTime.. #
...# $
Now..$ '
}// 	
;//	 

await11 
_context11 
.11 
AssetAssignments11 '
.11' (
AddAsync11( 0
(110 1

assignment111 ;
)11; <
;11< =
await22 
_context22 
.22 
SaveChangesAsync22 '
(22' (
)22( )
;22) *
return44 
$str44 )
;44) *
}55 
public77 

async77 
Task77 
<77 
string77 
>77 
AssignAssetAsync77 .
(77. /
AssetAssignInputDto77/ B
dto77C F
)77F G
{88 
var99 

assignment99 
=99 
await99 
_context99 '
.99' (
AssetAssignments99( 8
.:: 
Include:: 
(:: 
a:: 
=>:: 
a:: 
.:: 
Asset:: !
)::! "
.;; 
FirstOrDefaultAsync;;  
(;;  !
a;;! "
=>;;# %
a;;& '
.;;' (
AssignmentId;;( 4
==;;5 7
dto;;8 ;
.;;; <
AssignmentId;;< H
&&;;I K
a;;L M
.;;M N
Status;;N T
==;;U W
$str;;X c
&&;;d f
!;;g h
a;;h i
.;;i j
	IsDeleted;;j s
);;s t
;;;t u
if== 

(== 

assignment== 
==== 
null== 
)== 
throw>> 
new>>  
KeyNotFoundException>> *
(>>* +
$str>>+ J
)>>J K
;>>K L
if@@ 

(@@ 

assignment@@ 
.@@ 
Asset@@ 
.@@ 
Quantity@@ %
<@@& '

assignment@@( 2
.@@2 3
Quantity@@3 ;
)@@; <
throwAA 
newAA %
InvalidOperationExceptionAA /
(AA/ 0
$strAA0 X
)AAX Y
;AAY Z

assignmentCC 
.CC 
StatusCC 
=CC 
$strCC &
;CC& '

assignmentDD 
.DD 
AssignedDateDD 
=DD  !
dtoDD" %
.DD% &
AssignedDateDD& 2
;DD2 3

assignmentEE 
.EE 
AssetEE 
.EE 
QuantityEE !
-=EE" $

assignmentEE% /
.EE/ 0
QuantityEE0 8
;EE8 9
awaitGG 
_contextGG 
.GG 
SaveChangesAsyncGG '
(GG' (
)GG( )
;GG) *
returnII 
$strII -
;II- .
}JJ 
publicLL 

asyncLL 
TaskLL 
<LL 
stringLL 
>LL 
RequestReturnAsyncLL 0
(LL0 1
intLL1 4
assignmentIdLL5 A
,LLA B
intLLC F

employeeIdLLG Q
)LLQ R
{MM 
varNN 

assignmentNN 
=NN 
awaitNN 
_contextNN '
.NN' (
AssetAssignmentsNN( 8
.OO 
FirstOrDefaultAsyncOO  
(OO  !
aOO! "
=>OO# %
aOO& '
.OO' (
AssignmentIdOO( 4
==OO5 7
assignmentIdOO8 D
&&OOE G
aOOH I
.OOI J
UserIdOOJ P
==OOQ S

employeeIdOOT ^
&&OO_ a
aOOb c
.OOc d
StatusOOd j
==OOk m
$strOOn x
)OOx y
;OOy z
ifQQ 

(QQ 

assignmentQQ 
==QQ 
nullQQ 
)QQ 
throwRR 
newRR #
BadHttpRequestExceptionRR -
(RR- .
$strRR. U
)RRU V
;RRV W
ifTT 

(TT 

assignmentTT 
.TT 
ReturnStatusTT #
==TT$ &
$strTT' 2
)TT2 3
throwUU 
newUU #
BadHttpRequestExceptionUU -
(UU- .
$strUU. Q
)UUQ R
;UUR S

assignmentWW 
.WW 
ReturnStatusWW 
=WW  !
$strWW" -
;WW- .
_contextXX 
.XX 
AssetAssignmentsXX !
.XX! "
UpdateXX" (
(XX( )

assignmentXX) 3
)XX3 4
;XX4 5
awaitYY 
_contextYY 
.YY 
SaveChangesAsyncYY '
(YY' (
)YY( )
;YY) *
return[[ 
$str[[ 7
;[[7 8
}\\ 
public]] 

async]] 
Task]] 
<]] 
string]] 
>]] 
ApproveReturnAsync]] 0
(]]0 1
int]]1 4
assignmentId]]5 A
)]]A B
{^^ 
var__ 

assignment__ 
=__ 
await__ 
_context__ '
.__' (
AssetAssignments__( 8
.`` 
Include`` 
(`` 
a`` 
=>`` 
a`` 
.`` 
Asset`` !
)``! "
.aa 
FirstOrDefaultAsyncaa  
(aa  !
aaa! "
=>aa# %
abb 
.bb 
AssignmentIdbb 
==bb !
assignmentIdbb" .
&&bb/ 1
acc 
.cc 
Statuscc 
==cc 
$strcc &
&&cc' )
add 
.dd 
ReturnStatusdd 
==dd !
$strdd" -
)dd- .
;dd. /
ifff 

(ff 

assignmentff 
==ff 
nullff 
)ff 
throwgg 
newgg %
InvalidOperationExceptiongg /
(gg/ 0
$strgg0 J
)ggJ K
;ggK L

assignmentii 
.ii 
Statusii 
=ii 
$strii &
;ii& '

assignmentjj 
.jj 
ReturnStatusjj 
=jj  !
$strjj" ,
;jj, -

assignmentkk 
.kk 

ReturnDatekk 
=kk 
DateTimekk  (
.kk( )
Nowkk) ,
;kk, -

assignmentll 
.ll 
Assetll 
.ll 
Quantityll !
+=ll" $

assignmentll% /
.ll/ 0
Quantityll0 8
;ll8 9
awaitnn 
_contextnn 
.nn 
SaveChangesAsyncnn '
(nn' (
)nn( )
;nn) *
returnoo 
$stroo 6
;oo6 7
}pp 
publicrr 

asyncrr 
Taskrr 
<rr 
Listrr 
<rr 
AssetAssignDtorr )
>rr) *
>rr* +%
GetAllReturnRequestsAsyncrr, E
(rrE F
)rrF G
{ss 
vartt 
returnstt 
=tt 
awaittt 
_contexttt $
.tt$ %
AssetAssignmentstt% 5
.uu 
Includeuu 
(uu 
auu 
=>uu 
auu 
.uu 
Useruu  
)uu  !
.vv 
Includevv 
(vv 
avv 
=>vv 
avv 
.vv 
Assetvv !
)vv! "
.ww 
Whereww 
(ww 
aww 
=>ww 
aww 
.ww 
Statusww  
==ww! #
$strww$ .
&&ww/ 1
aww2 3
.ww3 4
ReturnStatusww4 @
==wwA C
$strwwD O
&&wwP R
!wwS T
awwT U
.wwU V
	IsDeletedwwV _
)ww_ `
.xx 
ToListAsyncxx 
(xx 
)xx 
;xx 
returnzz 
_mapperzz 
.zz 
Mapzz 
<zz 
Listzz 
<zz  
AssetAssignDtozz  .
>zz. /
>zz/ 0
(zz0 1
returnszz1 8
)zz8 9
;zz9 :
}{{ 
public|| 

async|| 
Task|| 
<|| 
List|| 
<|| 
AssetAssignDto|| )
>||) *
>||* +&
GetAllPendingRequestsAsync||, F
(||F G
)||G H
{}} 
var~~ 
pendingRequests~~ 
=~~ 
await~~ #
_context~~$ ,
.~~, -
AssetAssignments~~- =
. 
Include 
( 
a 
=> 
a 
. 
Asset !
)! "
.
€€ 
Include
€€ 
(
€€ 
a
€€ 
=>
€€ 
a
€€ 
.
€€ 
User
€€  
)
€€  !
.
 
Where
 
(
 
a
 
=>
 
a
 
.
 
Status
  
==
! #
$str
$ /
&&
0 2
!
3 4
a
4 5
.
5 6
	IsDeleted
6 ?
)
? @
.
‚‚ 
ToListAsync
‚‚ 
(
‚‚ 
)
‚‚ 
;
‚‚ 
return
„„ 
_mapper
„„ 
.
„„ 
Map
„„ 
<
„„ 
List
„„ 
<
„„  
AssetAssignDto
„„  .
>
„„. /
>
„„/ 0
(
„„0 1
pendingRequests
„„1 @
)
„„@ A
;
„„A B
}
…… 
public
†† 

async
†† 
Task
†† 
<
†† 
string
†† 
>
††  
RejectRequestAsync
†† 0
(
††0 1
int
††1 4
assignmentId
††5 A
)
††A B
{
‡‡ 
var
 

assignment
 
=
 
await
 
_context
 '
.
' (
AssetAssignments
( 8
.
‰‰ !
FirstOrDefaultAsync
‰‰  
(
‰‰  !
a
‰‰! "
=>
‰‰# %
a
‰‰& '
.
‰‰' (
AssignmentId
‰‰( 4
==
‰‰5 7
assignmentId
‰‰8 D
&&
‰‰E G
!
‰‰H I
a
‰‰I J
.
‰‰J K
	IsDeleted
‰‰K T
)
‰‰T U
;
‰‰U V
if
‹‹ 

(
‹‹ 

assignment
‹‹ 
==
‹‹ 
null
‹‹ 
||
‹‹ !

assignment
‹‹" ,
.
‹‹, -
Status
‹‹- 3
!=
‹‹4 6
$str
‹‹7 B
)
‹‹B C
throw
 
new
 '
InvalidOperationException
 /
(
/ 0
$str
0 `
)
` a
;
a b

assignment
 
.
 
Status
 
=
 
$str
 &
;
& '
await
 
_context
 
.
 
SaveChangesAsync
 '
(
' (
)
( )
;
) *
return
‘‘ 
$str
‘‘ /
;
‘‘/ 0
}
’’ 
public
““ 

async
““ 
Task
““ 
<
““ 
string
““ 
>
““ &
RejectReturnRequestAsync
““ 6
(
““6 7
int
““7 :
assignmentId
““; G
)
““G H
{
”” 
var
•• 

assignment
•• 
=
•• 
await
•• 
_context
•• '
.
••' (
AssetAssignments
••( 8
.
–– !
FirstOrDefaultAsync
––  
(
––  !
a
––! "
=>
––# %
a
––& '
.
––' (
AssignmentId
––( 4
==
––5 7
assignmentId
––8 D
&&
––E G
a
––H I
.
––I J
ReturnStatus
––J V
==
––W Y
$str
––Z e
)
––e f
;
––f g
if
 

(
 

assignment
 
==
 
null
 
)
 
throw
™™ 
new
™™ '
InvalidOperationException
™™ /
(
™™/ 0
$str
™™0 _
)
™™_ `
;
™™` a

assignment
›› 
.
›› 
ReturnStatus
›› 
=
››  !
$str
››" ,
;
››, -
await
 
_context
 
.
 
SaveChangesAsync
 '
(
' (
)
( )
;
) *
return
 
$str
 )
;
) *
}
 
public
   

async
   
Task
   
<
   
List
   
<
   
AssetAssignDto
   )
>
  ) *
>
  * +'
GetAllAssignedAssetsAsync
  , E
(
  E F
)
  F G
{
΅΅ 
var
ΆΆ 
assignments
ΆΆ 
=
ΆΆ 
await
ΆΆ 
_context
ΆΆ  (
.
ΆΆ( )
AssetAssignments
ΆΆ) 9
.
££ 
Include
££ 
(
££ 
a
££ 
=>
££ 
a
££ 
.
££ 
Asset
££ !
)
££! "
.
££" #
ThenInclude
££# .
(
££. /
a
££/ 0
=>
££1 3
a
££4 5
.
££5 6
AssetCategory
££6 C
)
££C D
.
¤¤ 
Include
¤¤ 
(
¤¤ 
a
¤¤ 
=>
¤¤ 
a
¤¤ 
.
¤¤ 
User
¤¤  
)
¤¤  !
.
¥¥ 
Where
¥¥ 
(
¥¥ 
a
¥¥ 
=>
¥¥ 
(
¥¥ 
a
¥¥ 
.
¥¥ 
Status
¥¥ !
==
¥¥" $
$str
¥¥% /
||
¥¥0 2
a
¥¥3 4
.
¥¥4 5
Status
¥¥5 ;
==
¥¥< >
$str
¥¥? I
||
¥¥J L
a
¥¥M N
.
¥¥N O
Status
¥¥O U
==
¥¥V X
$str
¥¥Y c
)
¥¥c d
&&
¥¥e g
!
¥¥h i
a
¥¥i j
.
¥¥j k
Asset
¥¥k p
.
¥¥p q
	IsDeleted
¥¥q z
)
¥¥z {
.
¦¦ 
ToListAsync
¦¦ 
(
¦¦ 
)
¦¦ 
;
¦¦ 
return
¨¨ 
assignments
¨¨ 
.
¨¨ 
Select
¨¨ !
(
¨¨! "
a
¨¨" #
=>
¨¨$ &
new
¨¨' *
AssetAssignDto
¨¨+ 9
{
©© 	
AssignmentId
ªª 
=
ªª 
a
ªª 
.
ªª 
AssignmentId
ªª )
,
ªª) *
UserId
«« 
=
«« 
a
«« 
.
«« 
UserId
«« 
,
«« 
UserName
¬¬ 
=
¬¬ 
a
¬¬ 
.
¬¬ 
User
¬¬ 
.
¬¬ 
FullName
¬¬ &
,
¬¬& '
AssetId
­­ 
=
­­ 
a
­­ 
.
­­ 
AssetId
­­ 
,
­­  
	AssetName
®® 
=
®® 
a
®® 
.
®® 
Asset
®® 
.
®®  
	AssetName
®®  )
,
®®) *

AssetModel
―― 
=
―― 
a
―― 
.
―― 
Asset
――  
.
――  !

AssetModel
――! +
,
――+ ,
CategoryName
°° 
=
°° 
a
°° 
.
°° 
Asset
°° "
.
°°" #
AssetCategory
°°# 0
.
°°0 1
CategoryName
°°1 =
,
°°= >
ImageUrl
±± 
=
±± 
a
±± 
.
±± 
Asset
±± 
.
±± 
ImageUrl
±± '
,
±±' (
Quantity
²² 
=
²² 
a
²² 
.
²² 
Quantity
²² !
,
²²! "
Status
³³ 
=
³³ 
a
³³ 
.
³³ 
Status
³³ 
,
³³ 
AssignedDate
΄΄ 
=
΄΄ 
a
΄΄ 
.
΄΄ 
AssignedDate
΄΄ )
,
΄΄) *

ReturnDate
µµ 
=
µµ 
a
µµ 
.
µµ 

ReturnDate
µµ %
}
¶¶ 	
)
¶¶	 

.
¶¶
 
ToList
¶¶ 
(
¶¶ 
)
¶¶ 
;
¶¶ 
}
·· 
public
ΈΈ 

async
ΈΈ 
Task
ΈΈ 
<
ΈΈ 
List
ΈΈ 
<
ΈΈ 
AssetAssignDto
ΈΈ )
>
ΈΈ) *
>
ΈΈ* +)
GetAllRejectedRequestsAsync
ΈΈ, G
(
ΈΈG H
)
ΈΈH I
{
ΉΉ 
var
ΊΊ 
rejected
ΊΊ 
=
ΊΊ 
await
ΊΊ 
_context
ΊΊ %
.
ΊΊ% &
AssetAssignments
ΊΊ& 6
.
»» 
Include
»» 
(
»» 
a
»» 
=>
»» 
a
»» 
.
»» 
User
»»  
)
»»  !
.
ΌΌ 
Include
ΌΌ 
(
ΌΌ 
a
ΌΌ 
=>
ΌΌ 
a
ΌΌ 
.
ΌΌ 
Asset
ΌΌ !
)
ΌΌ! "
.
½½ 
Where
½½ 
(
½½ 
a
½½ 
=>
½½ 
a
½½ 
.
½½ 
Status
½½  
==
½½! #
$str
½½$ .
&&
½½/ 1
!
½½2 3
a
½½3 4
.
½½4 5
	IsDeleted
½½5 >
)
½½> ?
.
ΎΎ 
ToListAsync
ΎΎ 
(
ΎΎ 
)
ΎΎ 
;
ΎΎ 
return
ΐΐ 
_mapper
ΐΐ 
.
ΐΐ 
Map
ΐΐ 
<
ΐΐ 
List
ΐΐ 
<
ΐΐ  
AssetAssignDto
ΐΐ  .
>
ΐΐ. /
>
ΐΐ/ 0
(
ΐΐ0 1
rejected
ΐΐ1 9
)
ΐΐ9 :
;
ΐΐ: ;
}
ΑΑ 
public
ΒΒ 

async
ΒΒ 
Task
ΒΒ 
<
ΒΒ 
List
ΒΒ 
<
ΒΒ 
AssetAssignDto
ΒΒ )
>
ΒΒ) *
>
ΒΒ* +
GetMyAssetsAsync
ΒΒ, <
(
ΒΒ< =
int
ΒΒ= @
userId
ΒΒA G
)
ΒΒG H
{
ΓΓ 
var
ΔΔ 
assignments
ΔΔ 
=
ΔΔ 
await
ΔΔ 
_context
ΔΔ  (
.
ΔΔ( )
AssetAssignments
ΔΔ) 9
.
ΕΕ 
Include
ΕΕ 
(
ΕΕ 
a
ΕΕ 
=>
ΕΕ 
a
ΕΕ 
.
ΕΕ 
Asset
ΕΕ !
)
ΕΕ! "
.
ΕΕ" #
ThenInclude
ΕΕ# .
(
ΕΕ. /
a
ΕΕ/ 0
=>
ΕΕ1 3
a
ΕΕ4 5
.
ΕΕ5 6
AssetCategory
ΕΕ6 C
)
ΕΕC D
.
ΖΖ 
Where
ΖΖ 
(
ΖΖ 
a
ΖΖ 
=>
ΖΖ 
a
ΗΗ 
.
ΗΗ 
UserId
ΗΗ 
==
ΗΗ 
userId
ΗΗ "
&&
ΗΗ# %
(
ΘΘ 
a
ΘΘ 
.
ΘΘ 
Status
ΘΘ 
==
ΘΘ 
$str
ΘΘ '
||
ΘΘ( *
a
ΘΘ+ ,
.
ΘΘ, -
Status
ΘΘ- 3
==
ΘΘ4 6
$str
ΘΘ7 A
||
ΘΘB D
a
ΘΘE F
.
ΘΘF G
Status
ΘΘG M
==
ΘΘN P
$str
ΘΘQ [
)
ΘΘ[ \
&&
ΘΘ] _
!
ΙΙ 
a
ΙΙ 
.
ΙΙ 
Asset
ΙΙ 
.
ΙΙ 
	IsDeleted
ΙΙ "
)
ΙΙ" #
.
ΚΚ 
ToListAsync
ΚΚ 
(
ΚΚ 
)
ΚΚ 
;
ΚΚ 
return
ΜΜ 
assignments
ΜΜ 
.
ΜΜ 
Select
ΜΜ !
(
ΜΜ! "
a
ΜΜ" #
=>
ΜΜ$ &
new
ΜΜ' *
AssetAssignDto
ΜΜ+ 9
{
ΝΝ 	
AssignmentId
ΞΞ 
=
ΞΞ 
a
ΞΞ 
.
ΞΞ 
AssignmentId
ΞΞ )
,
ΞΞ) *
UserId
ΟΟ 
=
ΟΟ 
a
ΟΟ 
.
ΟΟ 
UserId
ΟΟ 
,
ΟΟ 
AssetId
ΠΠ 
=
ΠΠ 
a
ΠΠ 
.
ΠΠ 
AssetId
ΠΠ 
,
ΠΠ  
	AssetName
ΡΡ 
=
ΡΡ 
a
ΡΡ 
.
ΡΡ 
Asset
ΡΡ 
.
ΡΡ  
	AssetName
ΡΡ  )
,
ΡΡ) *

AssetModel
ÒÒ 
=
ÒÒ 
a
ÒÒ 
.
ÒÒ 
Asset
ÒÒ  
.
ÒÒ  !

AssetModel
ÒÒ! +
,
ÒÒ+ ,
CategoryName
ΣΣ 
=
ΣΣ 
a
ΣΣ 
.
ΣΣ 
Asset
ΣΣ "
.
ΣΣ" #
AssetCategory
ΣΣ# 0
.
ΣΣ0 1
CategoryName
ΣΣ1 =
,
ΣΣ= >
ImageUrl
ΤΤ 
=
ΤΤ 
a
ΤΤ 
.
ΤΤ 
Asset
ΤΤ 
.
ΤΤ 
ImageUrl
ΤΤ '
,
ΤΤ' (
Quantity
ΥΥ 
=
ΥΥ 
a
ΥΥ 
.
ΥΥ 
Quantity
ΥΥ !
,
ΥΥ! "
Status
ΦΦ 
=
ΦΦ 
a
ΦΦ 
.
ΦΦ 
Status
ΦΦ 
,
ΦΦ 
AssignedDate
ΧΧ 
=
ΧΧ 
a
ΧΧ 
.
ΧΧ 
AssignedDate
ΧΧ )
,
ΧΧ) *

ReturnDate
ΨΨ 
=
ΨΨ 
a
ΨΨ 
.
ΨΨ 

ReturnDate
ΨΨ %
}
ΩΩ 	
)
ΩΩ	 

.
ΩΩ
 
ToList
ΩΩ 
(
ΩΩ 
)
ΩΩ 
;
ΩΩ 
}
ΪΪ 
}ΫΫ ζO
2D:\VSCodezz\AssetPortal\AssetManagement\Program.cs
	namespace 	
AssetManagement
 
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
var 
builder 
= 
WebApplication (
.( )
CreateBuilder) 6
(6 7
args7 ;
); <
;< =
builder 
. 
Services 
. 
AddControllers +
(+ ,
), -
;- .
builder 
. 
Services 
. 
AddSwaggerGen *
(* +
options+ 2
=>3 5
{ 
options 
. 

SwaggerDoc "
(" #
$str# '
,' (
new) ,
OpenApiInfo- 8
{9 :
Title; @
=A B
$strC Y
,Y Z
Version[ b
=c d
$stre i
}j k
)k l
;l m
options 
. !
AddSecurityDefinition -
(- .
$str. 6
,6 7
new8 ;!
OpenApiSecurityScheme< Q
{ 
Name 
= 
$str *
,* +
Type 
= 
SecuritySchemeType -
.- .
Http. 2
,2 3
Scheme 
= 
$str %
,% &
BearerFormat  
=! "
$str# (
,( )
In 
= 
ParameterLocation *
.* +
Header+ 1
,1 2
Description 
=  !
$str" B
}   
)   
;   
options"" 
."" "
AddSecurityRequirement"" .
("". /
new""/ 2&
OpenApiSecurityRequirement""3 M
{## 
{$$ 
new%% !
OpenApiSecurityScheme%% 1
{&& 
	Reference'' %
=''& '
new''( +
OpenApiReference'', <
{(( 
Type))  $
=))% &
ReferenceType))' 4
.))4 5
SecurityScheme))5 C
,))C D
Id**  "
=**# $
$str**% -
}++ 
},, 
,,, 
Array-- 
.-- 
Empty-- #
<--# $
string--$ *
>--* +
(--+ ,
)--, -
}.. 
}// 
)// 
;// 
}00 
)00 
;00 
builder33 
.33 
Services33 
.33 
AddDbContext33 )
<33) * 
ApplicationDbContext33* >
>33> ?
(33? @
options33@ G
=>33H J
options44 
.44 
UseSqlServer44 $
(44$ %
builder44% ,
.44, -
Configuration44- :
.44: ;
GetConnectionString44; N
(44N O
$str44O b
)44b c
)44c d
)44d e
;44e f
builder77 
.77 
Services77 
.77 
AddAutoMapper77 *
(77* +
typeof77+ 1
(771 2
MappingProfile772 @
)77@ A
)77A B
;77B C
builder:: 
.:: 
Services:: 
.:: 
	AddScoped:: &
<::& '
ITokenService::' 4
,::4 5
TokenService::6 B
>::B C
(::C D
)::D E
;::E F
builder;; 
.;; 
Services;; 
.;; 
	AddScoped;; &
<;;& '
IAuthService;;' 3
,;;3 4
AuthService;;5 @
>;;@ A
(;;A B
);;B C
;;;C D
builder<< 
.<< 
Services<< 
.<< 
	AddScoped<< &
<<<& '
IUserService<<' 3
,<<3 4
UserService<<5 @
><<@ A
(<<A B
)<<B C
;<<C D
builder== 
.== 
Services== 
.== 
	AddScoped== &
<==& '
ICategoryService==' 7
,==7 8
CategoryService==9 H
>==H I
(==I J
)==J K
;==K L
builder>> 
.>> 
Services>> 
.>> 
	AddScoped>> &
<>>& '
IAssetService>>' 4
,>>4 5
AssetService>>6 B
>>>B C
(>>C D
)>>D E
;>>E F
builder?? 
.?? 
Services?? 
.?? 
	AddScoped?? &
<??& '#
IAssetAssignmentService??' >
,??> ?"
AssetAssignmentService??@ V
>??V W
(??W X
)??X Y
;??Y Z
builder@@ 
.@@ 
Services@@ 
.@@ 
	AddScoped@@ &
<@@& '"
IServiceRequestService@@' =
,@@= >!
ServiceRequestService@@? T
>@@T U
(@@U V
)@@V W
;@@W X
builderAA 
.AA 
ServicesAA 
.AA 
	AddScopedAA &
<AA& ' 
IAuditRequestServiceAA' ;
,AA; <
AuditRequestServiceAA= P
>AAP Q
(AAQ R
)AAR S
;AAS T
varDD 
jwtSettingsDD 
=DD 
builderDD %
.DD% &
ConfigurationDD& 3
.DD3 4

GetSectionDD4 >
(DD> ?
$strDD? D
)DDD E
;DDE F
varEE 
keyValueEE 
=EE 
jwtSettingsEE &
[EE& '
$strEE' ,
]EE, -
??EE. 0
throwEE1 6
newEE7 :%
InvalidOperationExceptionEE; T
(EET U
$strEEU g
)EEg h
;EEh i
varFF 
keyFF 
=FF 
EncodingFF 
.FF 
UTF8FF #
.FF# $
GetBytesFF$ ,
(FF, -
keyValueFF- 5
)FF5 6
;FF6 7
builderHH 
.HH 
ServicesHH 
.HH 
AddAuthenticationHH .
(HH. /
optionsHH/ 6
=>HH7 9
{II 
optionsJJ 
.JJ %
DefaultAuthenticateSchemeJJ 1
=JJ2 3
JwtBearerDefaultsJJ4 E
.JJE F 
AuthenticationSchemeJJF Z
;JJZ [
optionsKK 
.KK "
DefaultChallengeSchemeKK .
=KK/ 0
JwtBearerDefaultsKK1 B
.KKB C 
AuthenticationSchemeKKC W
;KKW X
}LL 
)LL 
.MM 
AddJwtBearerMM 
(MM 
optionsMM !
=>MM" $
{NN 
optionsOO 
.OO  
RequireHttpsMetadataOO ,
=OO- .
falseOO/ 4
;OO4 5
optionsPP 
.PP 
	SaveTokenPP !
=PP" #
truePP$ (
;PP( )
optionsQQ 
.QQ %
TokenValidationParametersQQ 1
=QQ2 3
newQQ4 7%
TokenValidationParametersQQ8 Q
{RR 
ValidateIssuerSS "
=SS# $
trueSS% )
,SS) *
ValidateAudienceTT $
=TT% &
trueTT' +
,TT+ ,
ValidateLifetimeUU $
=UU% &
trueUU' +
,UU+ ,$
ValidateIssuerSigningKeyVV ,
=VV- .
trueVV/ 3
,VV3 4
ValidIssuerWW 
=WW  !
jwtSettingsWW" -
[WW- .
$strWW. 6
]WW6 7
,WW7 8
ValidAudienceXX !
=XX" #
jwtSettingsXX$ /
[XX/ 0
$strXX0 :
]XX: ;
,XX; <
IssuerSigningKeyYY $
=YY% &
newYY' * 
SymmetricSecurityKeyYY+ ?
(YY? @
keyYY@ C
)YYC D
,YYD E
RoleClaimTypeZZ !
=ZZ" #

ClaimTypesZZ$ .
.ZZ. /
RoleZZ/ 3
}[[ 
;[[ 
}\\ 
)\\ 
;\\ 
builder__ 
.__ 
Services__ 
.__ 
AddCors__ $
(__$ %
options__% ,
=>__- /
{`` 
optionsaa 
.aa 
	AddPolicyaa !
(aa! "
$straa" ,
,aa, -
policyaa. 4
=>aa5 7
{bb 
policycc 
.cc 
AllowAnyOrigincc )
(cc) *
)cc* +
.dd 
AllowAnyHeaderdd )
(dd) *
)dd* +
.ee 
AllowAnyMethodee )
(ee) *
)ee* +
;ee+ ,
}ff 
)ff 
;ff 
}gg 
)gg 
;gg 
varii 
appii 
=ii 
builderii 
.ii 
Buildii #
(ii# $
)ii$ %
;ii% &
ifjj 
(jj 
appjj 
.jj 
Environmentjj 
.jj  
IsDevelopmentjj  -
(jj- .
)jj. /
)jj/ 0
{kk 
appll 
.ll %
UseDeveloperExceptionPagell -
(ll- .
)ll. /
;ll/ 0
appmm 
.mm 

UseSwaggermm 
(mm 
)mm  
;mm  !
appnn 
.nn 
UseSwaggerUInn  
(nn  !
)nn! "
;nn" #
}oo 
appqq 
.qq 
UseHttpsRedirectionqq #
(qq# $
)qq$ %
;qq% &
apprr 
.rr 
UseCorsrr 
(rr 
$strrr "
)rr" #
;rr# $
apptt 
.tt 
UseAuthenticationtt !
(tt! "
)tt" #
;tt# $
appuu 
.uu 
UseStaticFilesuu 
(uu 
)uu  
;uu  !
appvv 
.vv 
UseAuthorizationvv  
(vv  !
)vv! "
;vv" #
appxx 
.xx 
MapControllersxx 
(xx 
)xx  
;xx  !
appyy 
.yy 
Runyy 
(yy 
)yy 
;yy 
}zz 	
}{{ 
}|| ή 
6D:\VSCodezz\AssetPortal\AssetManagement\Models\User.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
User 
{ 
[		 	
Key			 
]		 
public

 
int

 
UserId

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 4
)4 5
]5 6
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% C
)C D
]D E
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[ 	
RegularExpression	 
( 
$str N
,N O
ErrorMessage 
= 
$str	 „
)
„ …
]
… †
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
[ 	
Phone	 
( 
ErrorMessage 
= 
$str 4
)4 5
]5 6
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
? 
Address 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
public   
Role   
Role   
{   
get   
;   
set    #
;  # $
}  % &
=  ' (
null  ) -
!  - .
;  . /
public!! 
ICollection!! 
<!! 
AssetAssignment!! *
>!!* +
Assignments!!, 7
{!!8 9
get!!: =
;!!= >
set!!? B
;!!B C
}!!D E
=!!F G
new!!H K
List!!L P
<!!P Q
AssetAssignment!!Q `
>!!` a
(!!a b
)!!b c
;!!c d
public"" 
bool"" 
	IsDeleted"" 
{"" 
get""  #
;""# $
set""% (
;""( )
}""* +
="", -
false"". 3
;""3 4
public## 
DateTime## 
?## 
	DeletedAt## "
{### $
get##% (
;##( )
set##* -
;##- .
}##/ 0
public$$ 
string$$ 
?$$ 

ResetToken$$ !
{$$" #
get$$$ '
;$$' (
set$$) ,
;$$, -
}$$. /
public%% 
DateTime%% 
?%% 
ResetTokenExpiry%% )
{%%* +
get%%, /
;%%/ 0
set%%1 4
;%%4 5
}%%6 7
}'' 
}(( Α
@D:\VSCodezz\AssetPortal\AssetManagement\Models\ServiceRequest.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
ServiceRequest 
{ 
[ 	
Key	 
] 
public		 
int		 
	RequestId		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
=' (
null) -
!- .
;. /
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public 
Asset 
Asset 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
[ 	
Required	 
] 
public 
DateTime 
RequestDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
	IssueType 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
[   	
Required  	 
]   
[!! 	
StringLength!!	 
(!! 
$num!! 
)!! 
]!! 
public"" 
string"" 
Status"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
=""+ ,
$str""- 6
;""6 7
}## 
}$$ †

6D:\VSCodezz\AssetPortal\AssetManagement\Models\Role.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
Role 
{ 
[ 	
Key	 
] 
public 
int 
RoleId 
{ 
get 
;  
set! $
;$ %
}& '
[

 	
Required

	 
(

 
ErrorMessage

 
=

  
$str

! 8
)

8 9
]

9 :
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
RoleName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
public 
ICollection 
< 
User 
>  
Users! &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
=5 6
new7 :
List; ?
<? @
User@ D
>D E
(E F
)F G
;G H
} 
} Σ
?D:\VSCodezz\AssetPortal\AssetManagement\Models\AssetCategory.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
AssetCategory 
{ 
[ 	
Key	 
] 
public		 
int		 

CategoryId		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
[ 	
Required	 
( 
ErrorMessage 
=  
$str! <
)< =
]= >
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
[ 	

JsonIgnore	 
] 
public 
ICollection 
< 
Asset  
>  !
Assets" (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
new9 <
List= A
<A B
AssetB G
>G H
(H I
)I J
;J K
public 
bool 
	IsDeleted 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
false. 3
;3 4
public 
DateTime 
? 
	DeletedAt "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} ­
<D:\VSCodezz\AssetPortal\AssetManagement\Models\AssetAudit.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 

AssetAudit 
{ 
[ 	
Key	 
] 
public		 
int		 
AuditId		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
=' (
null) -
!- .
;. /
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public 
Asset 
Asset 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
[ 	
Required	 
] 
public 
DateTime 
AuditRequestDate (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
DateTime 
? 
AuditResponseDate *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
$str- 6
;6 7
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Remarks 
{ 
get  #
;# $
set% (
;( )
}* +
=, -
string. 4
.4 5
Empty5 :
;: ;
} 
}   °
AD:\VSCodezz\AssetPortal\AssetManagement\Models\AssetAssignment.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
AssetAssignment  
{ 
[ 	
Key	 
] 
public		 
int		 
AssignmentId		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
User 
User 
{ 
get 
; 
set  #
;# $
}% &
=' (
null) -
!- .
;. /
[ 	
Required	 
] 
[ 	

ForeignKey	 
( 
$str 
) 
] 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public 
Asset 
Asset 
{ 
get  
;  !
set" %
;% &
}' (
=) *
null+ /
!/ 0
;0 1
[ 	
Required	 
] 
public 
DateTime 
AssignedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 

ReturnDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
$str- 7
;7 8
[ 	
Required	 
] 
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ L
)L M
]M N
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
=* +
$num, -
;- .
public   
bool   

IsReturned   
{    
get  ! $
;  $ %
set  & )
;  ) *
}  + ,
=  - .
false  / 4
;  4 5
public"" 
bool"" 
	IsDeleted"" 
{"" 
get""  #
;""# $
set""% (
;""( )
}""* +
="", -
false"". 3
;""3 4
public$$ 
string$$ 
ReturnStatus$$ "
{$$# $
get$$% (
;$$( )
set$$* -
;$$- .
}$$/ 0
=$$1 2
$str$$3 9
;$$9 :
}&& 
}'' ¶$
7D:\VSCodezz\AssetPortal\AssetManagement\Models\Asset.cs
	namespace 	
AssetManagement
 
. 
Models  
{ 
public 

class 
Asset 
{ 
[		 	
Key			 
]		 
public

 
int

 
AssetId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 9
)9 :
]: ;
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
	AssetName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 4
)4 5
]5 6
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 

AssetModel  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
string1 7
.7 8
Empty8 =
;= >
[ 	
Required	 
( 
ErrorMessage 
=  
$str! A
)A B
]B C
public 
DateTime 
ManufacturingDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
public 
DateTime 

ExpiryDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue !
,! "
ErrorMessage# /
=0 1
$str2 P
)P Q
]Q R
[ 	
	Precision	 
( 
$num 
, 
$num 
) 
] 
public 
decimal 

AssetValue !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
[   	
Range  	 
(   
$num   
,   
int   
.   
MaxValue   
,   
ErrorMessage    ,
=  - .
$str  / L
)  L M
]  M N
public!! 
int!! 
Quantity!! 
{!! 
get!! !
;!!! "
set!!# &
;!!& '
}!!( )
public## 
string## 
?## 
ImageUrl## 
{##  !
get##" %
;##% &
set##' *
;##* +
}##, -
[%% 	

ForeignKey%%	 
(%% 
$str%% #
)%%# $
]%%$ %
public&& 
int&& 

CategoryId&& 
{&& 
get&&  #
;&&# $
set&&% (
;&&( )
}&&* +
public(( 
AssetCategory(( 
AssetCategory(( *
{((+ ,
get((- 0
;((0 1
set((2 5
;((5 6
}((7 8
=((9 :
null((; ?
!((? @
;((@ A
public** 
ICollection** 
<** 
AssetAssignment** *
>*** +
Assignments**, 7
{**8 9
get**: =
;**= >
set**? B
;**B C
}**D E
=**F G
new**H K
List**L P
<**P Q
AssetAssignment**Q `
>**` a
(**a b
)**b c
;**c d
public,, 
bool,, 
	IsDeleted,, 
{,, 
get,,  #
;,,# $
set,,% (
;,,( )
},,* +
=,,, -
false,,. 3
;,,3 4
public-- 
DateTime-- 
?-- 
	DeletedAt-- "
{--# $
get--% (
;--( )
set--* -
;--- .
}--/ 0
}.. 
}// §
_D:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250712070606_RemoveAssetNumberFromAsset.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public 

partial 
class &
RemoveAssetNumberFromAsset 3
:4 5
	Migration6 ?
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str #
,# $
table 
: 
$str 
)  
;  !
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str #
,# $
table 
: 
$str 
,  
type 
: 
$str $
,$ %
	maxLength 
: 
$num 
, 
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
} 	
} 
} μ
eD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250711101242_AddReturnStatusToAssetAssignment.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public 

partial 
class ,
 AddReturnStatusToAssetAssignment 9
:: ;
	Migration< E
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str $
,$ %
table 
: 
$str )
,) *
type 
: 
$str %
,% &
nullable 
: 
false 
,  
defaultValue 
: 
$str  
)  !
;! "
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str $
,$ %
table 
: 
$str )
)) *
;* +
} 	
} 
} …
WD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250710113031_AddImageUrlToAsset.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public 

partial 
class 
AddImageUrlToAsset +
:, -
	Migration. 7
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str  
,  !
table 
: 
$str 
,  
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str  
,  !
table 
: 
$str 
)  
;  !
} 	
} 
} ’
XD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250709041805_AddResetTokenToUser.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public		 

partial		 
class		 
AddResetTokenToUser		 ,
:		- .
	Migration		/ 8
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
string' -
>- .
(. /
name 
: 
$str "
," #
table 
: 
$str 
, 
type 
: 
$str %
,% &
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str (
,( )
table 
: 
$str 
, 
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table   
:   
$str   
)   
;    
migrationBuilder"" 
."" 

DropColumn"" '
(""' (
name## 
:## 
$str## (
,##( )
table$$ 
:$$ 
$str$$ 
)$$ 
;$$  
}%% 	
}&& 
}'' Ο
WD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250625014544_AddServiceIsReturn.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public 

partial 
class 
AddServiceIsReturn +
:, -
	Migration. 7
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str "
," #
table 
: 
$str )
,) *
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
false #
)# $
;$ %
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str "
," #
table 
: 
$str )
)) *
;* +
} 	
} 
} Λ
UD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250625003402_AddedSoftDelete1.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public 

partial 
class 
AddedSoftDelete1 )
:* +
	Migration, 5
{		 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str !
,! "
table 
: 
$str )
,) *
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
false #
)# $
;$ %
} 	
	protected 
override 
void 
Down  $
($ %
MigrationBuilder% 5
migrationBuilder6 F
)F G
{ 	
migrationBuilder 
. 

DropColumn '
(' (
name 
: 
$str !
,! "
table 
: 
$str )
)) *
;* +
} 	
} 
} &
TD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250624215743_AddedSoftDelete.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public		 

partial		 
class		 
AddedSoftDelete		 (
:		) *
	Migration		+ 4
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str !
,! "
table 
: 
$str 
, 
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder 
. 
	AddColumn &
<& '
bool' +
>+ ,
(, -
name 
: 
$str !
,! "
table 
: 
$str 
, 
type 
: 
$str 
, 
nullable 
: 
false 
,  
defaultValue 
: 
false #
)# $
;$ %
migrationBuilder 
. 
	AddColumn &
<& '
DateTime' /
>/ 0
(0 1
name 
: 
$str !
,! "
table 
: 
$str 
,  
type 
: 
$str !
,! "
nullable 
: 
true 
) 
;  
migrationBuilder!! 
.!! 
	AddColumn!! &
<!!& '
bool!!' +
>!!+ ,
(!!, -
name"" 
:"" 
$str"" !
,""! "
table## 
:## 
$str## 
,##  
type$$ 
:$$ 
$str$$ 
,$$ 
nullable%% 
:%% 
false%% 
,%%  
defaultValue&& 
:&& 
false&& #
)&&# $
;&&$ %
migrationBuilder(( 
.(( 
	AddColumn(( &
<((& '
DateTime((' /
>((/ 0
(((0 1
name)) 
:)) 
$str)) !
,))! "
table** 
:** 
$str** (
,**( )
type++ 
:++ 
$str++ !
,++! "
nullable,, 
:,, 
true,, 
),, 
;,,  
migrationBuilder.. 
... 
	AddColumn.. &
<..& '
bool..' +
>..+ ,
(.., -
name// 
:// 
$str// !
,//! "
table00 
:00 
$str00 (
,00( )
type11 
:11 
$str11 
,11 
nullable22 
:22 
false22 
,22  
defaultValue33 
:33 
false33 #
)33# $
;33$ %
}44 	
	protected77 
override77 
void77 
Down77  $
(77$ %
MigrationBuilder77% 5
migrationBuilder776 F
)77F G
{88 	
migrationBuilder99 
.99 

DropColumn99 '
(99' (
name:: 
::: 
$str:: !
,::! "
table;; 
:;; 
$str;; 
);; 
;;;  
migrationBuilder== 
.== 

DropColumn== '
(==' (
name>> 
:>> 
$str>> !
,>>! "
table?? 
:?? 
$str?? 
)?? 
;??  
migrationBuilderAA 
.AA 

DropColumnAA '
(AA' (
nameBB 
:BB 
$strBB !
,BB! "
tableCC 
:CC 
$strCC 
)CC  
;CC  !
migrationBuilderEE 
.EE 

DropColumnEE '
(EE' (
nameFF 
:FF 
$strFF !
,FF! "
tableGG 
:GG 
$strGG 
)GG  
;GG  !
migrationBuilderII 
.II 

DropColumnII '
(II' (
nameJJ 
:JJ 
$strJJ !
,JJ! "
tableKK 
:KK 
$strKK (
)KK( )
;KK) *
migrationBuilderMM 
.MM 

DropColumnMM '
(MM' (
nameNN 
:NN 
$strNN !
,NN! "
tableOO 
:OO 
$strOO (
)OO( )
;OO) *
}PP 	
}QQ 
}RR γα
RD:\VSCodezz\AssetPortal\AssetManagement\Migrations\20250624180219_InitialCreate.cs
	namespace 	
AssetManagement
 
. 

Migrations $
{ 
public		 

partial		 
class		 
InitialCreate		 &
:		' (
	Migration		) 2
{

 
	protected 
override 
void 
Up  "
(" #
MigrationBuilder# 3
migrationBuilder4 D
)D E
{ 	
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str '
,' (
columns 
: 
table 
=> !
new" %
{ 

CategoryId 
=  
table! &
.& '
Column' -
<- .
int. 1
>1 2
(2 3
type3 7
:7 8
$str9 >
,> ?
nullable@ H
:H I
falseJ O
)O P
. 

Annotation #
(# $
$str$ 8
,8 9
$str: @
)@ A
,A B
CategoryName  
=! "
table# (
.( )
Column) /
</ 0
string0 6
>6 7
(7 8
type8 <
:< =
$str> M
,M N
	maxLengthO X
:X Y
$numZ ]
,] ^
nullable_ g
:g h
falsei n
)n o
} 
, 
constraints 
: 
table "
=># %
{ 
table 
. 

PrimaryKey $
($ %
$str% 9
,9 :
x; <
=>= ?
x@ A
.A B

CategoryIdB L
)L M
;M N
} 
) 
; 
migrationBuilder 
. 
CreateTable (
(( )
name 
: 
$str 
, 
columns 
: 
table 
=> !
new" %
{ 
RoleId 
= 
table "
." #
Column# )
<) *
int* -
>- .
(. /
type/ 3
:3 4
$str5 :
,: ;
nullable< D
:D E
falseF K
)K L
.   

Annotation   #
(  # $
$str  $ 8
,  8 9
$str  : @
)  @ A
,  A B
RoleName!! 
=!! 
table!! $
.!!$ %
Column!!% +
<!!+ ,
string!!, 2
>!!2 3
(!!3 4
type!!4 8
:!!8 9
$str!!: H
,!!H I
	maxLength!!J S
:!!S T
$num!!U W
,!!W X
nullable!!Y a
:!!a b
false!!c h
)!!h i
}"" 
,"" 
constraints## 
:## 
table## "
=>### %
{$$ 
table%% 
.%% 

PrimaryKey%% $
(%%$ %
$str%%% /
,%%/ 0
x%%1 2
=>%%3 5
x%%6 7
.%%7 8
RoleId%%8 >
)%%> ?
;%%? @
}&& 
)&& 
;&& 
migrationBuilder(( 
.(( 
CreateTable(( (
(((( )
name)) 
:)) 
$str)) 
,)) 
columns** 
:** 
table** 
=>** !
new**" %
{++ 
AssetId,, 
=,, 
table,, #
.,,# $
Column,,$ *
<,,* +
int,,+ .
>,,. /
(,,/ 0
type,,0 4
:,,4 5
$str,,6 ;
,,,; <
nullable,,= E
:,,E F
false,,G L
),,L M
.-- 

Annotation-- #
(--# $
$str--$ 8
,--8 9
$str--: @
)--@ A
,--A B
AssetNumber.. 
=..  !
table.." '
...' (
Column..( .
<... /
string../ 5
>..5 6
(..6 7
type..7 ;
:..; <
$str..= K
,..K L
	maxLength..M V
:..V W
$num..X Z
,..Z [
nullable..\ d
:..d e
false..f k
)..k l
,..l m
	AssetName// 
=// 
table//  %
.//% &
Column//& ,
<//, -
string//- 3
>//3 4
(//4 5
type//5 9
://9 :
$str//; J
,//J K
	maxLength//L U
://U V
$num//W Z
,//Z [
nullable//\ d
://d e
false//f k
)//k l
,//l m

AssetModel00 
=00  
table00! &
.00& '
Column00' -
<00- .
string00. 4
>004 5
(005 6
type006 :
:00: ;
$str00< K
,00K L
	maxLength00M V
:00V W
$num00X [
,00[ \
nullable00] e
:00e f
false00g l
)00l m
,00m n
ManufacturingDate11 %
=11& '
table11( -
.11- .
Column11. 4
<114 5
DateTime115 =
>11= >
(11> ?
type11? C
:11C D
$str11E P
,11P Q
nullable11R Z
:11Z [
false11\ a
)11a b
,11b c

ExpiryDate22 
=22  
table22! &
.22& '
Column22' -
<22- .
DateTime22. 6
>226 7
(227 8
type228 <
:22< =
$str22> I
,22I J
nullable22K S
:22S T
false22U Z
)22Z [
,22[ \

AssetValue33 
=33  
table33! &
.33& '
Column33' -
<33- .
decimal33. 5
>335 6
(336 7
type337 ;
:33; <
$str33= L
,33L M
	precision33N W
:33W X
$num33Y [
,33[ \
scale33] b
:33b c
$num33d e
,33e f
nullable33g o
:33o p
false33q v
)33v w
,33w x
Quantity44 
=44 
table44 $
.44$ %
Column44% +
<44+ ,
int44, /
>44/ 0
(440 1
type441 5
:445 6
$str447 <
,44< =
nullable44> F
:44F G
false44H M
)44M N
,44N O

CategoryId55 
=55  
table55! &
.55& '
Column55' -
<55- .
int55. 1
>551 2
(552 3
type553 7
:557 8
$str559 >
,55> ?
nullable55@ H
:55H I
false55J O
)55O P
}66 
,66 
constraints77 
:77 
table77 "
=>77# %
{88 
table99 
.99 

PrimaryKey99 $
(99$ %
$str99% 0
,990 1
x992 3
=>994 6
x997 8
.998 9
AssetId999 @
)99@ A
;99A B
table:: 
.:: 

ForeignKey:: $
(::$ %
name;; 
:;; 
$str;; D
,;;D E
column<< 
:<< 
x<<  !
=><<" $
x<<% &
.<<& '

CategoryId<<' 1
,<<1 2
principalTable== &
:==& '
$str==( 9
,==9 :
principalColumn>> '
:>>' (
$str>>) 5
,>>5 6
onDelete??  
:??  !
ReferentialAction??" 3
.??3 4
Cascade??4 ;
)??; <
;??< =
}@@ 
)@@ 
;@@ 
migrationBuilderBB 
.BB 
CreateTableBB (
(BB( )
nameCC 
:CC 
$strCC 
,CC 
columnsDD 
:DD 
tableDD 
=>DD !
newDD" %
{EE 
UserIdFF 
=FF 
tableFF "
.FF" #
ColumnFF# )
<FF) *
intFF* -
>FF- .
(FF. /
typeFF/ 3
:FF3 4
$strFF5 :
,FF: ;
nullableFF< D
:FFD E
falseFFF K
)FFK L
.GG 

AnnotationGG #
(GG# $
$strGG$ 8
,GG8 9
$strGG: @
)GG@ A
,GGA B
FullNameHH 
=HH 
tableHH $
.HH$ %
ColumnHH% +
<HH+ ,
stringHH, 2
>HH2 3
(HH3 4
typeHH4 8
:HH8 9
$strHH: I
,HHI J
	maxLengthHHK T
:HHT U
$numHHV Y
,HHY Z
nullableHH[ c
:HHc d
falseHHe j
)HHj k
,HHk l
EmailII 
=II 
tableII !
.II! "
ColumnII" (
<II( )
stringII) /
>II/ 0
(II0 1
typeII1 5
:II5 6
$strII7 F
,IIF G
nullableIIH P
:IIP Q
falseIIR W
)IIW X
,IIX Y
PasswordJJ 
=JJ 
tableJJ $
.JJ$ %
ColumnJJ% +
<JJ+ ,
stringJJ, 2
>JJ2 3
(JJ3 4
typeJJ4 8
:JJ8 9
$strJJ: I
,JJI J
nullableJJK S
:JJS T
falseJJU Z
)JJZ [
,JJ[ \
PhoneNumberKK 
=KK  !
tableKK" '
.KK' (
ColumnKK( .
<KK. /
stringKK/ 5
>KK5 6
(KK6 7
typeKK7 ;
:KK; <
$strKK= L
,KKL M
nullableKKN V
:KKV W
trueKKX \
)KK\ ]
,KK] ^
AddressLL 
=LL 
tableLL #
.LL# $
ColumnLL$ *
<LL* +
stringLL+ 1
>LL1 2
(LL2 3
typeLL3 7
:LL7 8
$strLL9 H
,LLH I
	maxLengthLLJ S
:LLS T
$numLLU X
,LLX Y
nullableLLZ b
:LLb c
trueLLd h
)LLh i
,LLi j
RoleIdMM 
=MM 
tableMM "
.MM" #
ColumnMM# )
<MM) *
intMM* -
>MM- .
(MM. /
typeMM/ 3
:MM3 4
$strMM5 :
,MM: ;
nullableMM< D
:MMD E
falseMMF K
)MMK L
}NN 
,NN 
constraintsOO 
:OO 
tableOO "
=>OO# %
{PP 
tableQQ 
.QQ 

PrimaryKeyQQ $
(QQ$ %
$strQQ% /
,QQ/ 0
xQQ1 2
=>QQ3 5
xQQ6 7
.QQ7 8
UserIdQQ8 >
)QQ> ?
;QQ? @
tableRR 
.RR 

ForeignKeyRR $
(RR$ %
nameSS 
:SS 
$strSS 5
,SS5 6
columnTT 
:TT 
xTT  !
=>TT" $
xTT% &
.TT& '
RoleIdTT' -
,TT- .
principalTableUU &
:UU& '
$strUU( /
,UU/ 0
principalColumnVV '
:VV' (
$strVV) 1
,VV1 2
onDeleteWW  
:WW  !
ReferentialActionWW" 3
.WW3 4
CascadeWW4 ;
)WW; <
;WW< =
}XX 
)XX 
;XX 
migrationBuilderZZ 
.ZZ 
CreateTableZZ (
(ZZ( )
name[[ 
:[[ 
$str[[ (
,[[( )
columns\\ 
:\\ 
table\\ 
=>\\ !
new\\" %
{]] 
AssignmentId^^  
=^^! "
table^^# (
.^^( )
Column^^) /
<^^/ 0
int^^0 3
>^^3 4
(^^4 5
type^^5 9
:^^9 :
$str^^; @
,^^@ A
nullable^^B J
:^^J K
false^^L Q
)^^Q R
.__ 

Annotation__ #
(__# $
$str__$ 8
,__8 9
$str__: @
)__@ A
,__A B
UserId`` 
=`` 
table`` "
.``" #
Column``# )
<``) *
int``* -
>``- .
(``. /
type``/ 3
:``3 4
$str``5 :
,``: ;
nullable``< D
:``D E
false``F K
)``K L
,``L M
AssetIdaa 
=aa 
tableaa #
.aa# $
Columnaa$ *
<aa* +
intaa+ .
>aa. /
(aa/ 0
typeaa0 4
:aa4 5
$straa6 ;
,aa; <
nullableaa= E
:aaE F
falseaaG L
)aaL M
,aaM N
AssignedDatebb  
=bb! "
tablebb# (
.bb( )
Columnbb) /
<bb/ 0
DateTimebb0 8
>bb8 9
(bb9 :
typebb: >
:bb> ?
$strbb@ K
,bbK L
nullablebbM U
:bbU V
falsebbW \
)bb\ ]
,bb] ^

ReturnDatecc 
=cc  
tablecc! &
.cc& '
Columncc' -
<cc- .
DateTimecc. 6
>cc6 7
(cc7 8
typecc8 <
:cc< =
$strcc> I
,ccI J
nullableccK S
:ccS T
trueccU Y
)ccY Z
,ccZ [
Statusdd 
=dd 
tabledd "
.dd" #
Columndd# )
<dd) *
stringdd* 0
>dd0 1
(dd1 2
typedd2 6
:dd6 7
$strdd8 F
,ddF G
	maxLengthddH Q
:ddQ R
$numddS U
,ddU V
nullableddW _
:dd_ `
falsedda f
)ddf g
,ddg h
Quantityee 
=ee 
tableee $
.ee$ %
Columnee% +
<ee+ ,
intee, /
>ee/ 0
(ee0 1
typeee1 5
:ee5 6
$stree7 <
,ee< =
nullableee> F
:eeF G
falseeeH M
)eeM N
}ff 
,ff 
constraintsgg 
:gg 
tablegg "
=>gg# %
{hh 
tableii 
.ii 

PrimaryKeyii $
(ii$ %
$strii% :
,ii: ;
xii< =
=>ii> @
xiiA B
.iiB C
AssignmentIdiiC O
)iiO P
;iiP Q
tablejj 
.jj 

ForeignKeyjj $
(jj$ %
namekk 
:kk 
$strkk B
,kkB C
columnll 
:ll 
xll  !
=>ll" $
xll% &
.ll& '
AssetIdll' .
,ll. /
principalTablemm &
:mm& '
$strmm( 0
,mm0 1
principalColumnnn '
:nn' (
$strnn) 2
,nn2 3
onDeleteoo  
:oo  !
ReferentialActionoo" 3
.oo3 4
Cascadeoo4 ;
)oo; <
;oo< =
tablepp 
.pp 

ForeignKeypp $
(pp$ %
nameqq 
:qq 
$strqq @
,qq@ A
columnrr 
:rr 
xrr  !
=>rr" $
xrr% &
.rr& '
UserIdrr' -
,rr- .
principalTabless &
:ss& '
$strss( /
,ss/ 0
principalColumntt '
:tt' (
$strtt) 1
,tt1 2
onDeleteuu  
:uu  !
ReferentialActionuu" 3
.uu3 4
Cascadeuu4 ;
)uu; <
;uu< =
}vv 
)vv 
;vv 
migrationBuilderxx 
.xx 
CreateTablexx (
(xx( )
nameyy 
:yy 
$stryy #
,yy# $
columnszz 
:zz 
tablezz 
=>zz !
newzz" %
{{{ 
AuditId|| 
=|| 
table|| #
.||# $
Column||$ *
<||* +
int||+ .
>||. /
(||/ 0
type||0 4
:||4 5
$str||6 ;
,||; <
nullable||= E
:||E F
false||G L
)||L M
.}} 

Annotation}} #
(}}# $
$str}}$ 8
,}}8 9
$str}}: @
)}}@ A
,}}A B
UserId~~ 
=~~ 
table~~ "
.~~" #
Column~~# )
<~~) *
int~~* -
>~~- .
(~~. /
type~~/ 3
:~~3 4
$str~~5 :
,~~: ;
nullable~~< D
:~~D E
false~~F K
)~~K L
,~~L M
AssetId 
= 
table #
.# $
Column$ *
<* +
int+ .
>. /
(/ 0
type0 4
:4 5
$str6 ;
,; <
nullable= E
:E F
falseG L
)L M
,M N
AuditRequestDate
€€ $
=
€€% &
table
€€' ,
.
€€, -
Column
€€- 3
<
€€3 4
DateTime
€€4 <
>
€€< =
(
€€= >
type
€€> B
:
€€B C
$str
€€D O
,
€€O P
nullable
€€Q Y
:
€€Y Z
false
€€[ `
)
€€` a
,
€€a b
AuditResponseDate
 %
=
& '
table
( -
.
- .
Column
. 4
<
4 5
DateTime
5 =
>
= >
(
> ?
type
? C
:
C D
$str
E P
,
P Q
nullable
R Z
:
Z [
true
\ `
)
` a
,
a b
Status
‚‚ 
=
‚‚ 
table
‚‚ "
.
‚‚" #
Column
‚‚# )
<
‚‚) *
string
‚‚* 0
>
‚‚0 1
(
‚‚1 2
type
‚‚2 6
:
‚‚6 7
$str
‚‚8 F
,
‚‚F G
	maxLength
‚‚H Q
:
‚‚Q R
$num
‚‚S U
,
‚‚U V
nullable
‚‚W _
:
‚‚_ `
false
‚‚a f
)
‚‚f g
,
‚‚g h
Remarks
ƒƒ 
=
ƒƒ 
table
ƒƒ #
.
ƒƒ# $
Column
ƒƒ$ *
<
ƒƒ* +
string
ƒƒ+ 1
>
ƒƒ1 2
(
ƒƒ2 3
type
ƒƒ3 7
:
ƒƒ7 8
$str
ƒƒ9 H
,
ƒƒH I
	maxLength
ƒƒJ S
:
ƒƒS T
$num
ƒƒU X
,
ƒƒX Y
nullable
ƒƒZ b
:
ƒƒb c
false
ƒƒd i
)
ƒƒi j
}
„„ 
,
„„ 
constraints
…… 
:
…… 
table
…… "
=>
……# %
{
†† 
table
‡‡ 
.
‡‡ 

PrimaryKey
‡‡ $
(
‡‡$ %
$str
‡‡% 5
,
‡‡5 6
x
‡‡7 8
=>
‡‡9 ;
x
‡‡< =
.
‡‡= >
AuditId
‡‡> E
)
‡‡E F
;
‡‡F G
table
 
.
 

ForeignKey
 $
(
$ %
name
‰‰ 
:
‰‰ 
$str
‰‰ =
,
‰‰= >
column
 
:
 
x
  !
=>
" $
x
% &
.
& '
AssetId
' .
,
. /
principalTable
‹‹ &
:
‹‹& '
$str
‹‹( 0
,
‹‹0 1
principalColumn
 '
:
' (
$str
) 2
,
2 3
onDelete
  
:
  !
ReferentialAction
" 3
.
3 4
Cascade
4 ;
)
; <
;
< =
table
 
.
 

ForeignKey
 $
(
$ %
name
 
:
 
$str
 ;
,
; <
column
 
:
 
x
  !
=>
" $
x
% &
.
& '
UserId
' -
,
- .
principalTable
‘‘ &
:
‘‘& '
$str
‘‘( /
,
‘‘/ 0
principalColumn
’’ '
:
’’' (
$str
’’) 1
,
’’1 2
onDelete
““  
:
““  !
ReferentialAction
““" 3
.
““3 4
Cascade
““4 ;
)
““; <
;
““< =
}
”” 
)
”” 
;
”” 
migrationBuilder
–– 
.
–– 
CreateTable
–– (
(
––( )
name
—— 
:
—— 
$str
—— '
,
——' (
columns
 
:
 
table
 
=>
 !
new
" %
{
™™ 
	RequestId
 
=
 
table
  %
.
% &
Column
& ,
<
, -
int
- 0
>
0 1
(
1 2
type
2 6
:
6 7
$str
8 =
,
= >
nullable
? G
:
G H
false
I N
)
N O
.
›› 

Annotation
›› #
(
››# $
$str
››$ 8
,
››8 9
$str
››: @
)
››@ A
,
››A B
UserId
 
=
 
table
 "
.
" #
Column
# )
<
) *
int
* -
>
- .
(
. /
type
/ 3
:
3 4
$str
5 :
,
: ;
nullable
< D
:
D E
false
F K
)
K L
,
L M
AssetId
 
=
 
table
 #
.
# $
Column
$ *
<
* +
int
+ .
>
. /
(
/ 0
type
0 4
:
4 5
$str
6 ;
,
; <
nullable
= E
:
E F
false
G L
)
L M
,
M N
RequestDate
 
=
  !
table
" '
.
' (
Column
( .
<
. /
DateTime
/ 7
>
7 8
(
8 9
type
9 =
:
= >
$str
? J
,
J K
nullable
L T
:
T U
false
V [
)
[ \
,
\ ]
	IssueType
 
=
 
table
  %
.
% &
Column
& ,
<
, -
string
- 3
>
3 4
(
4 5
type
5 9
:
9 :
$str
; I
,
I J
	maxLength
K T
:
T U
$num
V X
,
X Y
nullable
Z b
:
b c
false
d i
)
i j
,
j k
Description
   
=
    !
table
  " '
.
  ' (
Column
  ( .
<
  . /
string
  / 5
>
  5 6
(
  6 7
type
  7 ;
:
  ; <
$str
  = L
,
  L M
	maxLength
  N W
:
  W X
$num
  Y \
,
  \ ]
nullable
  ^ f
:
  f g
false
  h m
)
  m n
,
  n o
Status
΅΅ 
=
΅΅ 
table
΅΅ "
.
΅΅" #
Column
΅΅# )
<
΅΅) *
string
΅΅* 0
>
΅΅0 1
(
΅΅1 2
type
΅΅2 6
:
΅΅6 7
$str
΅΅8 F
,
΅΅F G
	maxLength
΅΅H Q
:
΅΅Q R
$num
΅΅S U
,
΅΅U V
nullable
΅΅W _
:
΅΅_ `
false
΅΅a f
)
΅΅f g
}
ΆΆ 
,
ΆΆ 
constraints
££ 
:
££ 
table
££ "
=>
££# %
{
¤¤ 
table
¥¥ 
.
¥¥ 

PrimaryKey
¥¥ $
(
¥¥$ %
$str
¥¥% 9
,
¥¥9 :
x
¥¥; <
=>
¥¥= ?
x
¥¥@ A
.
¥¥A B
	RequestId
¥¥B K
)
¥¥K L
;
¥¥L M
table
¦¦ 
.
¦¦ 

ForeignKey
¦¦ $
(
¦¦$ %
name
§§ 
:
§§ 
$str
§§ A
,
§§A B
column
¨¨ 
:
¨¨ 
x
¨¨  !
=>
¨¨" $
x
¨¨% &
.
¨¨& '
AssetId
¨¨' .
,
¨¨. /
principalTable
©© &
:
©©& '
$str
©©( 0
,
©©0 1
principalColumn
ªª '
:
ªª' (
$str
ªª) 2
,
ªª2 3
onDelete
««  
:
««  !
ReferentialAction
««" 3
.
««3 4
Cascade
««4 ;
)
««; <
;
««< =
table
¬¬ 
.
¬¬ 

ForeignKey
¬¬ $
(
¬¬$ %
name
­­ 
:
­­ 
$str
­­ ?
,
­­? @
column
®® 
:
®® 
x
®®  !
=>
®®" $
x
®®% &
.
®®& '
UserId
®®' -
,
®®- .
principalTable
―― &
:
――& '
$str
――( /
,
――/ 0
principalColumn
°° '
:
°°' (
$str
°°) 1
,
°°1 2
onDelete
±±  
:
±±  !
ReferentialAction
±±" 3
.
±±3 4
Cascade
±±4 ;
)
±±; <
;
±±< =
}
²² 
)
²² 
;
²² 
migrationBuilder
΄΄ 
.
΄΄ 
CreateIndex
΄΄ (
(
΄΄( )
name
µµ 
:
µµ 
$str
µµ 3
,
µµ3 4
table
¶¶ 
:
¶¶ 
$str
¶¶ )
,
¶¶) *
column
·· 
:
·· 
$str
·· !
)
··! "
;
··" #
migrationBuilder
ΉΉ 
.
ΉΉ 
CreateIndex
ΉΉ (
(
ΉΉ( )
name
ΊΊ 
:
ΊΊ 
$str
ΊΊ 2
,
ΊΊ2 3
table
»» 
:
»» 
$str
»» )
,
»») *
column
ΌΌ 
:
ΌΌ 
$str
ΌΌ  
)
ΌΌ  !
;
ΌΌ! "
migrationBuilder
ΎΎ 
.
ΎΎ 
CreateIndex
ΎΎ (
(
ΎΎ( )
name
ΏΏ 
:
ΏΏ 
$str
ΏΏ .
,
ΏΏ. /
table
ΐΐ 
:
ΐΐ 
$str
ΐΐ $
,
ΐΐ$ %
column
ΑΑ 
:
ΑΑ 
$str
ΑΑ !
)
ΑΑ! "
;
ΑΑ" #
migrationBuilder
ΓΓ 
.
ΓΓ 
CreateIndex
ΓΓ (
(
ΓΓ( )
name
ΔΔ 
:
ΔΔ 
$str
ΔΔ -
,
ΔΔ- .
table
ΕΕ 
:
ΕΕ 
$str
ΕΕ $
,
ΕΕ$ %
column
ΖΖ 
:
ΖΖ 
$str
ΖΖ  
)
ΖΖ  !
;
ΖΖ! "
migrationBuilder
ΘΘ 
.
ΘΘ 
CreateIndex
ΘΘ (
(
ΘΘ( )
name
ΙΙ 
:
ΙΙ 
$str
ΙΙ ,
,
ΙΙ, -
table
ΚΚ 
:
ΚΚ 
$str
ΚΚ 
,
ΚΚ  
column
ΛΛ 
:
ΛΛ 
$str
ΛΛ $
)
ΛΛ$ %
;
ΛΛ% &
migrationBuilder
ΝΝ 
.
ΝΝ 
CreateIndex
ΝΝ (
(
ΝΝ( )
name
ΞΞ 
:
ΞΞ 
$str
ΞΞ 2
,
ΞΞ2 3
table
ΟΟ 
:
ΟΟ 
$str
ΟΟ (
,
ΟΟ( )
column
ΠΠ 
:
ΠΠ 
$str
ΠΠ !
)
ΠΠ! "
;
ΠΠ" #
migrationBuilder
ÒÒ 
.
ÒÒ 
CreateIndex
ÒÒ (
(
ÒÒ( )
name
ΣΣ 
:
ΣΣ 
$str
ΣΣ 1
,
ΣΣ1 2
table
ΤΤ 
:
ΤΤ 
$str
ΤΤ (
,
ΤΤ( )
column
ΥΥ 
:
ΥΥ 
$str
ΥΥ  
)
ΥΥ  !
;
ΥΥ! "
migrationBuilder
ΧΧ 
.
ΧΧ 
CreateIndex
ΧΧ (
(
ΧΧ( )
name
ΨΨ 
:
ΨΨ 
$str
ΨΨ '
,
ΨΨ' (
table
ΩΩ 
:
ΩΩ 
$str
ΩΩ 
,
ΩΩ 
column
ΪΪ 
:
ΪΪ 
$str
ΪΪ  
)
ΪΪ  !
;
ΪΪ! "
}
ΫΫ 	
	protected
ήή 
override
ήή 
void
ήή 
Down
ήή  $
(
ήή$ %
MigrationBuilder
ήή% 5
migrationBuilder
ήή6 F
)
ήήF G
{
ίί 	
migrationBuilder
ΰΰ 
.
ΰΰ 
	DropTable
ΰΰ &
(
ΰΰ& '
name
αα 
:
αα 
$str
αα (
)
αα( )
;
αα) *
migrationBuilder
γγ 
.
γγ 
	DropTable
γγ &
(
γγ& '
name
δδ 
:
δδ 
$str
δδ #
)
δδ# $
;
δδ$ %
migrationBuilder
ζζ 
.
ζζ 
	DropTable
ζζ &
(
ζζ& '
name
ηη 
:
ηη 
$str
ηη '
)
ηη' (
;
ηη( )
migrationBuilder
ιι 
.
ιι 
	DropTable
ιι &
(
ιι& '
name
κκ 
:
κκ 
$str
κκ 
)
κκ 
;
κκ  
migrationBuilder
μμ 
.
μμ 
	DropTable
μμ &
(
μμ& '
name
νν 
:
νν 
$str
νν 
)
νν 
;
νν 
migrationBuilder
οο 
.
οο 
	DropTable
οο &
(
οο& '
name
ππ 
:
ππ 
$str
ππ '
)
ππ' (
;
ππ( )
migrationBuilder
ςς 
.
ςς 
	DropTable
ςς &
(
ςς& '
name
σσ 
:
σσ 
$str
σσ 
)
σσ 
;
σσ 
}
ττ 	
}
υυ 
}φφ ώ(
BD:\VSCodezz\AssetPortal\AssetManagement\Mappings\MappingProfile.cs
	namespace		 	
AssetManagement		
 
.		 
Mappings		 "
{

 
public 

class 
MappingProfile 
:  !
Profile" )
{ 
public 
MappingProfile 
( 
) 
{ 	
	CreateMap 
< 
AssetCreateDto $
,$ %
Asset& +
>+ ,
(, -
)- .
;. /
	CreateMap 
< 
AssetAssignDto $
,$ %
AssetAssignment& 5
>5 6
(6 7
)7 8
;8 9
	CreateMap 
< 
Asset 
, 
AssetDetailDto +
>+ ,
(, -
)- .
. 
	ForMember 
( 
dest 
=> 
dest  $
.$ %
CategoryName% 1
,1 2
opt3 6
=>7 9
opt: =
.= >
MapFrom> E
(E F
srcF I
=>J L
srcM P
.P Q
AssetCategoryQ ^
.^ _
CategoryName_ k
)k l
)l m
;m n
	CreateMap 
< 
Asset 
, 
AssetAvailableDto .
>. /
(/ 0
)0 1
. 
	ForMember 
( 
dest 
=> 
dest  $
.$ %
CategoryName% 1
,1 2
opt3 6
=>7 9
opt: =
.= >
MapFrom> E
(E F
srcF I
=>J L
srcM P
.P Q
AssetCategoryQ ^
.^ _
CategoryName_ k
)k l
)l m
;m n
	CreateMap 
< 
AssetAssignment %
,% &
AssetAssignDto' 5
>5 6
(6 7
)7 8
. 
	ForMember 
( 
dest 
=> 
dest  $
.$ %
	AssetName% .
,. /
opt0 3
=>4 6
opt7 :
.: ;
MapFrom; B
(B C
srcC F
=>G I
srcJ M
.M N
AssetN S
.S T
	AssetNameT ]
)] ^
)^ _
. 
	ForMember 
( 
dest 
=> 
dest  $
.$ %
UserName% -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
UserM Q
.Q R
FullNameR Z
)Z [
)[ \
;\ ]
	CreateMap 
< 
CreateEmployeeDto '
,' (
User) -
>- .
(. /
)/ 0
;0 1
	CreateMap 
< 
User 
, 
UserDto #
># $
($ %
)% &
.   
	ForMember   
(   
dest   
=>   
dest    $
.  $ %
UserId  % +
,  + ,
opt  - 0
=>  1 3
opt  4 7
.  7 8
MapFrom  8 ?
(  ? @
src  @ C
=>  D F
src  G J
.  J K
UserId  K Q
)  Q R
)  R S
.!! 
	ForMember!! 
(!! 
dest!! 
=>!! 
dest!!  $
.!!$ %
Role!!% )
,!!) *
opt!!+ .
=>!!/ 1
opt!!2 5
.!!5 6
MapFrom!!6 =
(!!= >
src!!> A
=>!!B D
src!!E H
.!!H I
Role!!I M
.!!M N
RoleName!!N V
)!!V W
)!!W X
;!!X Y
	CreateMap## 
<## 
UpdateEmployeeDto## '
,##' (
User##) -
>##- .
(##. /
)##/ 0
;##0 1
	CreateMap&& 
<&& 
ServiceRequestDto&& '
,&&' (
ServiceRequest&&) 7
>&&7 8
(&&8 9
)&&9 :
;&&: ;
	CreateMap'' 
<'' 
ServiceUpdateDto'' &
,''& '
ServiceRequest''( 6
>''6 7
(''7 8
)''8 9
;''9 :
	CreateMap** 
<** 
AuditRequestDto** %
,**% &

AssetAudit**' 1
>**1 2
(**2 3
)**3 4
;**4 5
	CreateMap++ 
<++ 
AuditResponseDto++ &
,++& '

AssetAudit++( 2
>++2 3
(++3 4
)++4 5
;++5 6
	CreateMap.. 
<.. 
CategoryCreateDto.. '
,..' (
AssetCategory..) 6
>..6 7
(..7 8
)..8 9
...9 :

ReverseMap..: D
(..D E
)..E F
;..F G
	CreateMap// 
<// 
AssetCategory// #
,//# $
CategoryDto//% 0
>//0 1
(//1 2
)//2 3
;//3 4
}00 	
}11 
}22 θ
<D:\VSCodezz\AssetPortal\AssetManagement\DTOs\User\UserDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
User #
{ 
public 

class 
UserDto 
{ 
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
FullName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
public		 
string		 
Address		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
=		, -
string		. 4
.		4 5
Empty		5 :
;		: ;
public

 
string

 
Role

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
=

) *
string

+ 1
.

1 2
Empty

2 7
;

7 8
} 
} ό	
FD:\VSCodezz\AssetPortal\AssetManagement\DTOs\User\UpdateEmployeeDto.cs
public 
class 
UpdateEmployeeDto 
{ 
public 

int 
UserId 
{ 
get 
; 
set  
;  !
}" #
public 

string 
? 
FullName 
{ 
get !
;! "
set# &
;& '
}( )
[		 
EmailAddress		 
]		 
public

 

string

 
?

 
Email

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
[ 
Phone 

]
 
public 

string 
? 
PhoneNumber 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

string 
? 
Address 
{ 
get  
;  !
set" %
;% &
}' (
public 

string 
? 
RoleName 
{ 
get !
;! "
set# &
;& '
}( )
} β
FD:\VSCodezz\AssetPortal\AssetManagement\DTOs\User\CreateEmployeeDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
User #
{ 
public 

class 
CreateEmployeeDto "
{ 
[ 	
Required	 
] 
[		 	
StringLength			 
(		 
$num		 
)		 
]		 
public

 
string

 
?

 
FullName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
[ 	
Required	 
] 
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% <
)< =
]= >
public 
string 
? 
Email 
{ 
get "
;" #
set$ '
;' (
}) *
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
, 
MinimumLength '
=( )
$num* ,
,, -
ErrorMessage. :
=; <
$str= h
)h i
]i j
[ 	
RegularExpression	 
( 
$str )
,) *
ErrorMessage+ 7
=8 9
$str: [
)[ \
]\ ]
public 
string 
? 
PhoneNumber "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
? 
Address 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
[ 	
RegularExpression	 
( 
$str N
,N O
ErrorMessage 
= 
$str	 „
)
„ …
]
… †
public 
string 
? 
Password 
{  !
get" %
;% &
set' *
;* +
}, -
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
public 
string 
RoleName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
}   
}!! Ζ
ID:\VSCodezz\AssetPortal\AssetManagement\DTOs\Service\ServiceRequestDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Service &
{ 
public 

class 
ServiceRequestDto "
{ 
[ 	
Required	 
] 
public 
int 
AssignmentId 
{  !
get" %
;% &
set' *
;* +
}, -
[

 	
Required

	 
]

 
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage (
=) *
$str+ W
)W X
]X Y
public 
string 
Description !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
[ 	
Required	 
] 
[ 	
RegularExpression	 
( 
$str 4
,4 5
ErrorMessage6 B
=C D
$strE z
)z {
]{ |
public 
string 
	IssueType 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
} 
} μ
HD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Service\ServiceUpdateDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Service &
{ 
public 

class 
ServiceUpdateDto !
{ 
[ 	
Required	 
] 
public 
int 
ServiceRequestId #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[

 	
Required

	 
]

 
[ 	
RegularExpression	 
( 
$str K
,K L
ErrorMessage 
= 
$str ]
)] ^
]^ _
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
} 
} Ε
DD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Category\CategoryDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Category '
{ 
public 

class 
CategoryDto 
{ 
public 
int 

CategoryId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
} 
} 
JD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Category\CreateCategoryDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Category '
{ 
public 

class 
CategoryCreateDto "
{ 
[ 	
Required	 
] 
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage '
=( )
$str* W
)W X
]X Y
public		 
string		 
CategoryName		 "
{		# $
get		% (
;		( )
set		* -
;		- .
}		/ 0
=		1 2
string		3 9
.		9 :
Empty		: ?
;		? @
}

 
} ύ	
ID:\VSCodezz\AssetPortal\AssetManagement\DTOs\Auth\ResetPasswordRequest.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Auth #
{ 
public 

class  
ResetPasswordRequest %
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
public 
string 
Token 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
[

 	
Required

	 
]

 
[ 	
RegularExpression	 
( 
$str N
,N O
ErrorMessage 
= 
$str	 „
)
„ …
]
… †
public 
string 
NewPassword !
{" #
get$ '
;' (
set) ,
;, -
}. /
=0 1
string2 8
.8 9
Empty9 >
;> ?
} 
} 
BD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Auth\LoginResponse.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Auth #
{ 
public 

class 
LoginResponse 
{ 
public 
string 
Token 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
} 
} ί
AD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Auth\LoginRequest.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Auth #
{ 
public 

class 
LoginRequest 
{ 
[ 	
Required	 
] 
[ 	
EmailAddress	 
( 
ErrorMessage "
=# $
$str% <
)< =
]= >
public		 
string		 
Email		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
=		* +
string		, 2
.		2 3
Empty		3 8
;		8 9
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
} 
} ―
JD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Auth\ForgotPasswordRequest.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Auth #
{ 
public 

class !
ForgotPasswordRequest &
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
=* +
string, 2
.2 3
Empty3 8
;8 9
} 
} »

FD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Audit\AuditResponseDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Audit $
{ 
public 

class 
AuditResponseDto !
{ 
[ 	
Required	 
] 
public 
int 
AuditId 
{ 
get  
;  !
set" %
;% &
}' (
[

 	
Required

	 
]

 
[ 	
RegularExpression	 
( 
$str 3
,3 4
ErrorMessage5 A
=B C
$strD u
)u v
]v w
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
[ 	
StringLength	 
( 
$num 
, 
ErrorMessage (
=) *
$str+ S
)S T
]T U
public 
string 
? 
Remarks 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} ΰ
ED:\VSCodezz\AssetPortal\AssetManagement\DTOs\Audit\AuditRequestDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Audit $
{ 
public 

class 
AuditRequestDto  
{ 
[ 	
Required	 
] 
public 
int 
AssignmentId 
{  !
get" %
;% &
set' *
;* +
}, -
[

 	
Required

	 
]

 
public 
DateTime 
RequestedDate %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
} ΅$
DD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetUpdateDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetUpdateDto 
:  !
IValidatableObject" 4
{ 
[ 	
StringLength	 
( 
$num 
) 
] 
public		 
string		 
?		 
	AssetName		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 
? 

AssetModel !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
int 
? 

CategoryId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
? 
ManufacturingDate *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
DateTime 
? 

ExpiryDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue !
,! "
ErrorMessage# /
=0 1
$str2 W
)W X
]X Y
[ 	
	Precision	 
( 
$num 
, 
$num 
) 
] 
public 
decimal 
? 

AssetValue "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ M
)M N
]N O
public 
int 
? 
Quantity 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
ImageUrl 
{  !
get" %
;% &
set' *
;* +
}, -
public 
IEnumerable 
< 
ValidationResult +
>+ ,
Validate- 5
(5 6
ValidationContext6 G
validationContextH Y
)Y Z
{ 	
if   
(   
ManufacturingDate   !
.  ! "
HasValue  " *
)  * +
{!! 
if"" 
("" 
ManufacturingDate"" %
.""% &
Value""& +
.""+ ,
Year"", 0
<""1 2
$num""3 7
)""7 8
{## 
yield$$ 
return$$  
new$$! $
ValidationResult$$% 5
($$5 6
$str$$6 g
,$$g h
new$$i l
[$$l m
]$$m n
{$$o p
nameof$$q w
($$w x
ManufacturingDate	$$x ‰
)
$$‰ 
}
$$‹ 
)
$$ 
;
$$ 
}%% 
if&& 
(&& 
ManufacturingDate&& %
.&&% &
Value&&& +
>&&, -
DateTime&&. 6
.&&6 7
UtcNow&&7 =
)&&= >
{'' 
yield(( 
return((  
new((! $
ValidationResult((% 5
(((5 6
$str((6 c
,((c d
new((e h
[((h i
]((i j
{((k l
nameof((m s
(((s t
ManufacturingDate	((t …
)
((… †
}
((‡ 
)
(( ‰
;
((‰ 
})) 
}** 
if,, 
(,, 

ExpiryDate,, 
.,, 
HasValue,, #
&&,,$ &

ExpiryDate,,' 1
.,,1 2
Value,,2 7
<=,,8 :
DateTime,,; C
.,,C D
UtcNow,,D J
),,J K
{-- 
yield.. 
return.. 
new..  
ValidationResult..! 1
(..1 2
$str..2 V
,..V W
new..X [
[..[ \
]..\ ]
{..^ _
nameof..` f
(..f g

ExpiryDate..g q
)..q r
}..s t
)..t u
;..u v
}// 
}00 	
}11 
}22  
KD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetReturnRequestDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class !
AssetReturnRequestDto &
{ 
public 
int 
AssignmentId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public		 
string		 
	AssetName		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
=		. /
string		0 6
.		6 7
Empty		7 <
;		< =
public

 
int

 
UserId

 
{

 
get

 
;

  
set

! $
;

$ %
}

& '
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
DateTime 
AssignedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
ReturnStatus "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
} 
} ½
ED:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetRequestDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetRequestDto  
{ 
[ 	
Required	 
] 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
[

 	
Range

	 
(

 
$num

 
,

 
int

 
.

 
MaxValue

 
,

 
ErrorMessage

  ,
=

- .
$str

/ L
)

L M
]

M N
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
=* +
$num, -
;- .
} 
} Μ
DD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetDetailDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetDetailDto 
{ 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	AssetName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
public 
string 

AssetModel  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
string1 7
.7 8
Empty8 =
;= >
public		 
DateTime		 
ManufacturingDate		 )
{		* +
get		, /
;		/ 0
set		1 4
;		4 5
}		6 7
public

 
DateTime

 

ExpiryDate

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
decimal 

AssetValue !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
? 
ImageUrl 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Status 
=> 
DateTime  (
.( )
UtcNow) /
>0 1

ExpiryDate2 <
?= >
$str? H
:I J
$strK S
;S T
} 
} υ+
DD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetCreateDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetCreateDto 
:  !
IValidatableObject" 4
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
[		 	
StringLength			 
(		 
$num		 
)		 
]		 
public

 
string

 
	AssetName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
=

. /
string

0 6
.

6 7
Empty

7 <
;

< =
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 5
)5 6
]6 7
[ 	
StringLength	 
( 
$num 
) 
] 
public 
string 

AssetModel  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
string1 7
.7 8
Empty8 =
;= >
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
public 
int 

CategoryId 
{ 
get  #
;# $
set% (
;( )
}* +
[ 	
Required	 
( 
ErrorMessage 
=  
$str! B
)B C
]C D
public 
DateTime 
ManufacturingDate )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
public 
DateTime 

ExpiryDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
( 
ErrorMessage 
=  
$str! ;
); <
]< =
[ 	
Range	 
( 
$num 
, 
double 
. 
MaxValue !
,! "
ErrorMessage# /
=0 1
$str2 W
)W X
]X Y
[ 	
	Precision	 
( 
$num 
, 
$num 
) 
] 
public 
decimal 

AssetValue !
{" #
get$ '
;' (
set) ,
;, -
}. /
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 8
)8 9
]9 :
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ M
)M N
]N O
public   
int   
Quantity   
{   
get   !
;  ! "
set  # &
;  & '
}  ( )
public"" 
string"" 
?"" 
ImageUrl"" 
{""  !
get""" %
;""% &
set""' *
;""* +
}"", -
public$$ 
string$$ 
Status$$ 
=>$$ 
DateTime$$  (
.$$( )
UtcNow$$) /
>$$0 1

ExpiryDate$$2 <
?$$= >
$str$$? H
:$$I J
$str$$K S
;$$S T
public&& 
IEnumerable&& 
<&& 
ValidationResult&& +
>&&+ ,
Validate&&- 5
(&&5 6
ValidationContext&&6 G
validationContext&&H Y
)&&Y Z
{'' 	
if(( 
((( 
ManufacturingDate(( !
.((! "
Year((" &
<((' (
$num(() -
)((- .
{)) 
yield** 
return** 
new**  
ValidationResult**! 1
(**1 2
$str**2 c
,**c d
new**e h
[**h i
]**i j
{**k l
nameof**m s
(**s t
ManufacturingDate	**t …
)
**… †
}
**‡ 
)
** ‰
;
**‰ 
}++ 
if-- 
(-- 
ManufacturingDate-- !
>--" #
DateTime--$ ,
.--, -
UtcNow--- 3
)--3 4
{.. 
yield// 
return// 
new//  
ValidationResult//! 1
(//1 2
$str//2 _
,//_ `
new//a d
[//d e
]//e f
{//g h
nameof//i o
(//o p
ManufacturingDate	//p 
)
// ‚
}
//ƒ „
)
//„ …
;
//… †
}00 
if22 
(22 

ExpiryDate22 
<=22 
DateTime22 &
.22& '
UtcNow22' -
)22- .
{33 
yield44 
return44 
new44  
ValidationResult44! 1
(441 2
$str442 V
,44V W
new44X [
[44[ \
]44\ ]
{44^ _
nameof44` f
(44f g

ExpiryDate44g q
)44q r
}44s t
)44t u
;44u v
}55 
}66 	
}77 
}88 ο
GD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetAvailableDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetAvailableDto "
{ 
public 
int 
AssetId 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
	AssetName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
public 
string 

AssetModel  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
string1 7
.7 8
Empty8 =
;= >
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
public		 
int		 
Quantity		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
string

 
?

 
ImageUrl

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
} 
} ÿ
ID:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetAssignInputDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetAssignInputDto $
{ 
public 
int 
AssignmentId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
DateTime 
AssignedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
}		 Μ
DD:\VSCodezz\AssetPortal\AssetManagement\DTOs\Asset\AssetAssignDto.cs
	namespace 	
AssetManagement
 
. 
DTOs 
. 
Asset $
{ 
public 

class 
AssetAssignDto 
{ 
public 
int 
AssignmentId 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
UserId 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
=- .
string/ 5
.5 6
Empty6 ;
;; <
public

 
int

 
AssetId

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
string 
	AssetName 
{  !
get" %
;% &
set' *
;* +
}, -
=. /
string0 6
.6 7
Empty7 <
;< =
public 
string 

AssetModel  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
string1 7
.7 8
Empty8 =
;= >
public 
string 
CategoryName "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
string3 9
.9 :
Empty: ?
;? @
public 
string 
? 
ImageUrl 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
Quantity 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
=+ ,
string- 3
.3 4
Empty4 9
;9 :
public 
DateTime 
AssignedDate $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
DateTime 
? 

ReturnDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
} 
} »R
ED:\VSCodezz\AssetPortal\AssetManagement\Controllers\UserController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
UserController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IUserService %
_userService& 2
;2 3
public 
UserController 
( 
IUserService *
userService+ 6
)6 7
{ 	
_userService 
= 
userService &
;& '
} 	
[ 	
HttpPost	 
( 
$str #
)# $
]$ %
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
CreateEmployee) 7
(7 8
[8 9
FromBody9 A
]A B
CreateEmployeeDtoC T
dtoU X
)X Y
{ 	
try 
{ 
var 
result 
= 
await "
_userService# /
./ 0
CreateEmployeeAsync0 C
(C D
dtoD G
)G H
;H I
return 
Ok 
( 
new 
{ 
message  '
=( )
result* 0
}1 2
)2 3
;3 4
} 
catch 
( #
BadHttpRequestException *
ex+ -
)- .
{ 
return   

BadRequest   !
(  ! "
new  " %
{  & '
error  ( -
=  . /
ex  0 2
.  2 3
Message  3 :
}  ; <
)  < =
;  = >
}!! 
catch"" 
("" 
	Exception"" 
ex"" 
)""  
{## 
return$$ 

StatusCode$$ !
($$! "
$num$$" %
,$$% &
new$$' *
{$$+ ,
error$$- 2
=$$3 4
$str$$5 M
,$$M N
detail$$O U
=$$V W
ex$$X Z
.$$Z [
Message$$[ b
}$$c d
)$$d e
;$$e f
}%% 
}&& 	
[(( 	
HttpGet((	 
((( 
$str(( 
)(( 
](( 
[)) 	
	Authorize))	 
()) 
Roles)) 
=)) 
$str)) "
)))" #
]))# $
public** 
async** 
Task** 
<** 
IActionResult** '
>**' (
GetAllEmployees**) 8
(**8 9
)**9 :
{++ 	
try,, 
{-- 
var.. 
	employees.. 
=.. 
await..  %
_userService..& 2
...2 3 
GetAllEmployeesAsync..3 G
(..G H
)..H I
;..I J
return// 
Ok// 
(// 
	employees// #
)//# $
;//$ %
}00 
catch11 
(11 
	Exception11 
ex11 
)11  
{22 
return33 

StatusCode33 !
(33! "
$num33" %
,33% &
new33' *
{33+ ,
error33- 2
=333 4
ex335 7
.337 8
Message338 ?
}33@ A
)33A B
;33B C
}44 
}55 	
[77 	
HttpGet77	 
(77 
$str77 
)77 
]77 
[88 	
	Authorize88	 
(88 
Roles88 
=88 
$str88 %
)88% &
]88& '
public99 
async99 
Task99 
<99 
IActionResult99 '
>99' (
GetOwnProfile99) 6
(996 7
)997 8
{:: 	
try;; 
{<< 
var== 
userIdClaim== 
===  !
User==" &
.==& '
FindFirstValue==' 5
(==5 6

ClaimTypes==6 @
.==@ A
NameIdentifier==A O
)==O P
;==P Q
if>> 
(>> 
string>> 
.>> 
IsNullOrEmpty>> (
(>>( )
userIdClaim>>) 4
)>>4 5
||>>6 8
!>>9 :
int>>: =
.>>= >
TryParse>>> F
(>>F G
userIdClaim>>G R
,>>R S
out>>T W
var>>X [
userId>>\ b
)>>b c
)>>c d
return?? 
Unauthorized?? '
(??' (
new??( +
{??, -
error??. 3
=??4 5
$str??6 V
}??W X
)??X Y
;??Y Z
varAA 
profileAA 
=AA 
awaitAA #
_userServiceAA$ 0
.AA0 1
GetOwnProfileAsyncAA1 C
(AAC D
userIdAAD J
)AAJ K
;AAK L
ifCC 
(CC 
profileCC 
==CC 
nullCC #
)CC# $
returnDD 
NotFoundDD #
(DD# $
newDD$ '
{DD( )
errorDD* /
=DD0 1
$strDD2 F
}DDG H
)DDH I
;DDI J
returnFF 
OkFF 
(FF 
profileFF !
)FF! "
;FF" #
}GG 
catchHH 
(HH 
	ExceptionHH 
exHH 
)HH  
{II 
returnJJ 

StatusCodeJJ !
(JJ! "
$numJJ" %
,JJ% &
newJJ' *
{JJ+ ,
errorJJ- 2
=JJ3 4
$strJJ5 M
,JJM N
detailJJO U
=JJV W
exJJX Z
.JJZ [
MessageJJ[ b
}JJc d
)JJd e
;JJe f
}KK 
}LL 	
[NN 	
HttpPutNN	 
(NN 
$strNN "
)NN" #
]NN# $
[OO 	
	AuthorizeOO	 
(OO 
RolesOO 
=OO 
$strOO "
)OO" #
]OO# $
publicPP 
asyncPP 
TaskPP 
<PP 
IActionResultPP '
>PP' (
UpdateEmployeePP) 7
(PP7 8
[PP8 9
FromBodyPP9 A
]PPA B
UpdateEmployeeDtoPPC T
dtoPPU X
)PPX Y
{QQ 	
tryRR 
{SS 
varTT 
updatedUserTT 
=TT  !
awaitTT" '
_userServiceTT( 4
.TT4 5
UpdateEmployeeAsyncTT5 H
(TTH I
dtoTTI L
)TTL M
;TTM N
returnUU 
OkUU 
(UU 
updatedUserUU %
)UU% &
;UU& '
}VV 
catchWW 
(WW %
InvalidOperationExceptionWW ,
exWW- /
)WW/ 0
{XX 
returnYY 

BadRequestYY !
(YY! "
newYY" %
{YY& '
messageYY( /
=YY0 1
exYY2 4
.YY4 5
MessageYY5 <
}YY= >
)YY> ?
;YY? @
}ZZ 
catch[[ 
([[  
KeyNotFoundException[[ '
ex[[( *
)[[* +
{\\ 
return]] 
NotFound]] 
(]]  
new]]  #
{]]$ %
message]]& -
=]]. /
ex]]0 2
.]]2 3
Message]]3 :
}]]; <
)]]< =
;]]= >
}^^ 
catch__ 
(__ 
	Exception__ 
ex__ 
)__  
{`` 
returnaa 

StatusCodeaa !
(aa! "
$numaa" %
,aa% &
newaa' *
{aa+ ,
messageaa- 4
=aa5 6
$straa7 S
,aaS T
detailaaU [
=aa\ ]
exaa^ `
.aa` a
Messageaaa h
}aai j
)aaj k
;aak l
}bb 
}cc 	
[ee 	
HttpGetee	 
(ee 
$stree  
)ee  !
]ee! "
[ff 	
	Authorizeff	 
(ff 
Rolesff 
=ff 
$strff "
)ff" #
]ff# $
publicgg 
asyncgg 
Taskgg 
<gg 
IActionResultgg '
>gg' (
GetEmployeeByIdgg) 8
(gg8 9
intgg9 <
idgg= ?
)gg? @
{hh 	
tryii 
{jj 
varkk 
employeekk 
=kk 
awaitkk $
_userServicekk% 1
.kk1 2 
GetEmployeeByIdAsynckk2 F
(kkF G
idkkG I
)kkI J
;kkJ K
ifll 
(ll 
employeell 
==ll 
nullll  $
)ll$ %
returnmm 
NotFoundmm #
(mm# $
newmm$ '
{mm( )
messagemm* 1
=mm2 3
$strmm4 H
}mmI J
)mmJ K
;mmK L
returnoo 
Okoo 
(oo 
employeeoo "
)oo" #
;oo# $
}pp 
catchqq 
(qq 
	Exceptionqq 
exqq 
)qq  
{rr 
returnss 

StatusCodess !
(ss! "
$numss" %
,ss% &
newss' *
{ss+ ,
messagess- 4
=ss5 6
$strss7 Q
,ssQ R
detailssS Y
=ssZ [
exss\ ^
.ss^ _
Messagess_ f
}ssg h
)ssh i
;ssi j
}tt 
}uu 	
[ww 	

HttpDeleteww	 
(ww 
$strww #
)ww# $
]ww$ %
[xx 	
	Authorizexx	 
(xx 
Rolesxx 
=xx 
$strxx "
)xx" #
]xx# $
publicyy 
asyncyy 
Taskyy 
<yy 
IActionResultyy '
>yy' (
SoftDeleteEmployeeyy) ;
(yy; <
intyy< ?
idyy@ B
)yyB C
{zz 	
var{{ 
result{{ 
={{ 
await{{ 
_userService{{ +
.{{+ ,#
SoftDeleteEmployeeAsync{{, C
({{C D
id{{D F
){{F G
;{{G H
return|| 
Ok|| 
(|| 
new|| 
{|| 
message|| #
=||$ %
result||& ,
}||- .
)||. /
;||/ 0
}}} 	
}~~ 
} €2
OD:\VSCodezz\AssetPortal\AssetManagement\Controllers\ServiceRequestController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class $
ServiceRequestController )
:* +
ControllerBase, :
{ 
private 
readonly "
IServiceRequestService /"
_serviceRequestService0 F
;F G
public $
ServiceRequestController '
(' ("
IServiceRequestService( >!
serviceRequestService? T
)T U
{ 	"
_serviceRequestService "
=# $!
serviceRequestService% :
;: ;
} 	
[ 	
HttpPost	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str %
)% &
]& '
public 
async 
Task 
< 
IActionResult '
>' ( 
CreateServiceRequest) =
(= >
[> ?
FromBody? G
]G H
ServiceRequestDtoI Z
dto[ ^
)^ _
{ 	
try 
{ 
var 
userId 
= 
int  
.  !
Parse! &
(& '
User' +
.+ ,
FindFirstValue, :
(: ;

ClaimTypes; E
.E F
NameIdentifierF T
)T U
??V X
$strY \
)\ ]
;] ^
var 
success 
= 
await #"
_serviceRequestService$ :
.: ;%
CreateServiceRequestAsync; T
(T U
dtoU X
,X Y
userIdZ `
)` a
;a b
if 
( 
! 
success 
) 
return 

BadRequest %
(% &
$str& R
)R S
;S T
return   
Ok   
(   
$str   C
)  C D
;  D E
}!! 
catch"" 
("" 
	Exception"" 
ex"" 
)""  
{## 
return$$ 

BadRequest$$ !
($$! "
ex$$" $
.$$$ %
Message$$% ,
)$$, -
;$$- .
}%% 
}&& 	
[(( 	
HttpGet((	 
((( 
$str(( 
)(( 
](( 
[)) 	
	Authorize))	 
()) 
Roles)) 
=)) 
$str)) %
)))% &
]))& '
public** 
async** 
Task** 
<** 
IActionResult** '
>**' ( 
GetMyServiceRequests**) =
(**= >
)**> ?
{++ 	
try,, 
{-- 
var.. 
userId.. 
=.. 
int..  
...  !
Parse..! &
(..& '
User..' +
...+ ,
FindFirstValue.., :
(..: ;

ClaimTypes..; E
...E F
NameIdentifier..F T
)..T U
??..V X
$str..Y \
)..\ ]
;..] ^
var00 
requests00 
=00 
await00 $"
_serviceRequestService00% ;
.00; <%
GetMyServiceRequestsAsync00< U
(00U V
userId00V \
)00\ ]
;00] ^
return11 
Ok11 
(11 
requests11 "
)11" #
;11# $
}22 
catch33 
(33 
	Exception33 
)33 
{44 
return55 

StatusCode55 !
(55! "
$num55" %
,55% &
$str55' b
)55b c
;55c d
}66 
}77 	
[99 	
HttpGet99	 
(99 
$str99 
)99 
]99 
[:: 	
	Authorize::	 
(:: 
Roles:: 
=:: 
$str:: "
)::" #
]::# $
public;; 
async;; 
Task;; 
<;; 
IActionResult;; '
>;;' (!
GetAllServiceRequests;;) >
(;;> ?
);;? @
{<< 	
try== 
{>> 
var?? 
requests?? 
=?? 
await?? $"
_serviceRequestService??% ;
.??; <&
GetAllServiceRequestsAsync??< V
(??V W
)??W X
;??X Y
return@@ 
Ok@@ 
(@@ 
requests@@ "
)@@" #
;@@# $
}AA 
catchBB 
(BB 
	ExceptionBB 
)BB 
{CC 
returnDD 

StatusCodeDD !
(DD! "
$numDD" %
,DD% &
$strDD' a
)DDa b
;DDb c
}EE 
}FF 	
[HH 	
HttpPutHH	 
(HH 
$strHH 
)HH 
]HH 
[II 	
	AuthorizeII	 
(II 
RolesII 
=II 
$strII "
)II" #
]II# $
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
IActionResultJJ '
>JJ' (
UpdateServiceStatusJJ) <
(JJ< =
[JJ= >
FromBodyJJ> F
]JJF G
ServiceUpdateDtoJJH X
dtoJJY \
)JJ\ ]
{KK 	
tryLL 
{MM 
varNN 
successNN 
=NN 
awaitNN #"
_serviceRequestServiceNN$ :
.NN: ;+
UpdateServiceRequestStatusAsyncNN; Z
(NNZ [
dtoNN[ ^
)NN^ _
;NN_ `
ifOO 
(OO 
!OO 
successOO 
)OO 
returnPP 
NotFoundPP #
(PP# $
$strPP$ @
)PP@ A
;PPA B
returnRR 
OkRR 
(RR 
$strRR ;
)RR; <
;RR< =
}SS 
catchTT 
(TT 
	ExceptionTT 
)TT 
{UU 
returnVV 

StatusCodeVV !
(VV! "
$numVV" %
,VV% &
$strVV' ]
)VV] ^
;VV^ _
}WW 
}XX 	
}YY 
}ZZ „5
ID:\VSCodezz\AssetPortal\AssetManagement\Controllers\CategoryController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
CategoryController #
:$ %
ControllerBase& 4
{ 
private 
readonly 
ICategoryService )
_categoryService* :
;: ;
public 
CategoryController !
(! "
ICategoryService" 2
categoryService3 B
)B C
{ 	
_categoryService 
= 
categoryService .
;. /
} 	
[ 	
HttpGet	 
] 
public 
async 
Task 
< 
IActionResult +
>+ ,
GetAllCategories- =
(= >
)> ?
{ 
var 

categories 
=  
await! &
_categoryService' 7
.7 8!
GetAllCategoriesAsync8 M
(M N
)N O
;O P
var 
result 
= 

categories '
.' (
Select( .
(. /
c/ 0
=>1 3
new4 7
CategoryDto8 C
{ 

CategoryId 
=  
c! "
." #

CategoryId# -
,- .
CategoryName  
=! "
c# $
.$ %
CategoryName% 1
} 
) 
; 
return 
Ok 
( 
result  
)  !
;! "
} 
[!! 	
HttpGet!!	 
(!! 
$str!! 
)!! 
]!! 
public"" 
async"" 
Task"" 
<"" 
IActionResult"" +
>""+ ,
Get""- 0
(""0 1
int""1 4
id""5 7
)""7 8
{## 
try$$ 
{%% 
var&& 
category&&  
=&&! "
await&&# (
_categoryService&&) 9
.&&9 : 
GetCategoryByIdAsync&&: N
(&&N O
id&&O Q
)&&Q R
;&&R S
if'' 
('' 
category''  
==''! #
null''$ (
)''( )
return(( 
NotFound(( '
(((' (
$str((( =
)((= >
;((> ?
return)) 
Ok)) 
()) 
category)) &
)))& '
;))' (
}** 
catch++ 
(++ 
	Exception++  
ex++! #
)++# $
{,, 
return-- 

StatusCode-- %
(--% &
$num--& )
,--) *
$"--+ -
$str--- ^
{--^ _
ex--_ a
.--a b
Message--b i
}--i j
"--j k
)--k l
;--l m
}.. 
}// 
[11 	
HttpPost11	 
]11 
[22 	
	Authorize22	 
(22 
Roles22 
=22 
$str22 "
)22" #
]22# $
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
Create33) /
(33/ 0
CategoryCreateDto330 A
dto33B E
)33E F
{44 	
try55 
{66 
var77 
result77 
=77 
await77 "
_categoryService77# 3
.773 4
CreateCategoryAsync774 G
(77G H
dto77H K
)77K L
;77L M
return88 
Ok88 
(88 
result88  
)88  !
;88! "
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
return<< 

StatusCode<< !
(<<! "
$num<<" %
,<<% &
$"<<' )
$str<<) X
{<<X Y
ex<<Y [
.<<[ \
Message<<\ c
}<<c d
"<<d e
)<<e f
;<<f g
}== 
}>> 	
[@@ 	
HttpPut@@	 
(@@ 
$str@@ 
)@@ 
]@@ 
[AA 	
	AuthorizeAA	 
(AA 
RolesAA 
=AA 
$strAA "
)AA" #
]AA# $
publicBB 
asyncBB 
TaskBB 
<BB 
IActionResultBB '
>BB' (
UpdateBB) /
(BB/ 0
intBB0 3
idBB4 6
,BB6 7
CategoryCreateDtoBB8 I
dtoBBJ M
)BBM N
{CC 	
tryDD 
{EE 
varFF 
resultFF 
=FF 
awaitFF "
_categoryServiceFF# 3
.FF3 4
UpdateCategoryAsyncFF4 G
(FFG H
idFFH J
,FFJ K
dtoFFL O
)FFO P
;FFP Q
returnGG 
OkGG 
(GG 
resultGG  
)GG  !
;GG! "
}HH 
catchII 
(II 
	ExceptionII 
exII 
)II  
{JJ 
returnKK 

StatusCodeKK !
(KK! "
$numKK" %
,KK% &
$"KK' )
$strKK) X
{KKX Y
exKKY [
.KK[ \
MessageKK\ c
}KKc d
"KKd e
)KKe f
;KKf g
}LL 
}MM 	
[OO 	

HttpDeleteOO	 
(OO 
$strOO 
)OO 
]OO 
[PP 	
	AuthorizePP	 
(PP 
RolesPP 
=PP 
$strPP "
)PP" #
]PP# $
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ '
>QQ' (
DeleteQQ) /
(QQ/ 0
intQQ0 3
idQQ4 6
)QQ6 7
{RR 	
trySS 
{TT 
varUU 
resultUU 
=UU 
awaitUU "
_categoryServiceUU# 3
.UU3 4
DeleteCategoryAsyncUU4 G
(UUG H
idUUH J
)UUJ K
;UUK L
returnVV 
OkVV 
(VV 
resultVV  
)VV  !
;VV! "
}WW 
catchXX 
(XX 
	ExceptionXX 
exXX 
)XX  
{YY 
returnZZ 

StatusCodeZZ !
(ZZ! "
$numZZ" %
,ZZ% &
$"ZZ' )
$strZZ) X
{ZZX Y
exZZY [
.ZZ[ \
MessageZZ\ c
}ZZc d
"ZZd e
)ZZe f
;ZZf g
}[[ 
}\\ 	
}]] 
}^^ „/
ED:\VSCodezz\AssetPortal\AssetManagement\Controllers\AuthController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
AuthController 
:  !
ControllerBase" 0
{ 
private 
readonly 
IAuthService %
_authService& 2
;2 3
public 
AuthController 
( 
IAuthService *
authService+ 6
)6 7
{ 	
_authService 
= 
authService &
;& '
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
IActionResult '
>' (
Login) .
(. /
[/ 0
FromBody0 8
]8 9
LoginRequest: F
requestG N
)N O
{ 	
try 
{ 
var 
token 
= 
await !
_authService" .
.. /

LoginAsync/ 9
(9 :
request: A
)A B
;B C
var 
user 
= 
await  
_authService! -
.- .
GetUserByEmailAsync. A
(A B
requestB I
.I J
EmailJ O
)O P
;P Q
return 
Ok 
( 
new 
{ 
token 
, 
email 
= 
user  
.  !
Email! &
,& '
fullName   
=   
user   #
.  # $
FullName  $ ,
,  , -
role!! 
=!! 
user!! 
.!!  
Role!!  $
.!!$ %
RoleName!!% -
}"" 
)"" 
;"" 
}## 
catch$$ 
($$ '
UnauthorizedAccessException$$ .
ex$$/ 1
)$$1 2
{%% 
return&& 
Unauthorized&& #
(&&# $
new&&$ '
{&&( )
Message&&* 1
=&&2 3
ex&&4 6
.&&6 7
Message&&7 >
}&&? @
)&&@ A
;&&A B
}'' 
catch(( 
((( #
BadHttpRequestException(( *
ex((+ -
)((- .
{)) 
return** 

BadRequest** !
(**! "
new**" %
{**& '
Message**( /
=**0 1
ex**2 4
.**4 5
Message**5 <
}**= >
)**> ?
;**? @
}++ 
catch,, 
(,, 
	Exception,, 
),, 
{-- 
return.. 

StatusCode.. !
(..! "
$num.." %
,..% &
new..' *
{..+ ,
Message..- 4
=..5 6
$str..7 f
}..g h
)..h i
;..i j
}// 
}00 	
[22 	
HttpPost22	 
(22 
$str22 #
)22# $
]22$ %
public33 
async33 
Task33 
<33 
IActionResult33 '
>33' (
ForgotPassword33) 7
(337 8
[338 9
FromBody339 A
]33A B!
ForgotPasswordRequest33C X
request33Y `
)33` a
{44 	
try55 
{66 
var77 
token77 
=77 
await77 !
_authService77" .
.77. /
ForgotPasswordAsync77/ B
(77B C
request77C J
.77J K
Email77K P
)77P Q
;77Q R
return88 
Ok88 
(88 
new88 
{88 
message88  '
=88( )
$str88* L
,88L M
token88N S
}88T U
)88U V
;88V W
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
return<< 

BadRequest<< !
(<<! "
new<<" %
{<<& '
error<<( -
=<<. /
ex<<0 2
.<<2 3
Message<<3 :
}<<; <
)<<< =
;<<= >
}== 
}>> 	
[@@ 	
HttpPost@@	 
(@@ 
$str@@ "
)@@" #
]@@# $
publicAA 
asyncAA 
TaskAA 
<AA 
IActionResultAA '
>AA' (
ResetPasswordAA) 6
(AA6 7
[AA7 8
FromBodyAA8 @
]AA@ A 
ResetPasswordRequestAAB V
requestAAW ^
)AA^ _
{BB 	
tryCC 
{DD 
varEE 
messageEE 
=EE 
awaitEE #
_authServiceEE$ 0
.EE0 1
ResetPasswordAsyncEE1 C
(EEC D
requestEED K
)EEK L
;EEL M
returnFF 
OkFF 
(FF 
newFF 
{FF 
messageFF  '
}FF( )
)FF) *
;FF* +
}GG 
catchHH 
(HH '
UnauthorizedAccessExceptionHH .
exHH/ 1
)HH1 2
{II 
returnJJ 
UnauthorizedJJ #
(JJ# $
newJJ$ '
{JJ( )
errorJJ* /
=JJ0 1
exJJ2 4
.JJ4 5
MessageJJ5 <
}JJ= >
)JJ> ?
;JJ? @
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
returnNN 

BadRequestNN !
(NN! "
newNN" %
{NN& '
errorNN( -
=NN. /
exNN0 2
.NN2 3
MessageNN3 :
}NN; <
)NN< =
;NN= >
}OO 
}PP 	
}QQ 
}RR ·1
MD:\VSCodezz\AssetPortal\AssetManagement\Controllers\AuditRequestController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class "
AuditRequestController '
:( )
ControllerBase* 8
{ 
private 
readonly  
IAuditRequestService - 
_auditRequestService. B
;B C
public "
AuditRequestController %
(% & 
IAuditRequestService& :
auditRequestService; N
)N O
{ 	 
_auditRequestService  
=! "
auditRequestService# 6
;6 7
} 	
[ 	
HttpPost	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
CreateAuditRequest) ;
(; <
[< =
	FromQuery= F
]F G
intH K
assignmentIdL X
)X Y
{ 	
try 
{ 
var 
success 
= 
await # 
_auditRequestService$ 8
.8 9#
CreateAuditRequestAsync9 P
(P Q
assignmentIdQ ]
)] ^
;^ _
if 
( 
! 
success 
) 
return 

BadRequest %
(% &
$str& E
)E F
;F G
return 
Ok 
( 
$str ?
)? @
;@ A
} 
catch   
(   
	Exception   
)   
{!! 
return"" 

StatusCode"" !
(""! "
$num""" %
,""% &
$str""' \
)""\ ]
;""] ^
}## 
}$$ 	
[&& 	
HttpGet&&	 
(&& 
$str&& 
)&& 
]&& 
['' 	
	Authorize''	 
('' 
Roles'' 
='' 
$str'' %
)''% &
]''& '
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' (
GetMyAuditRequests(() ;
(((; <
)((< =
{)) 	
try** 
{++ 
var,, 
userId,, 
=,, 
int,,  
.,,  !
Parse,,! &
(,,& '
User,,' +
.,,+ ,
FindFirstValue,,, :
(,,: ;

ClaimTypes,,; E
.,,E F
NameIdentifier,,F T
),,T U
??,,V X
$str,,Y \
),,\ ]
;,,] ^
var-- 
audits-- 
=-- 
await-- " 
_auditRequestService--# 7
.--7 8#
GetMyAuditRequestsAsync--8 O
(--O P
userId--P V
)--V W
;--W X
return.. 
Ok.. 
(.. 
audits..  
)..  !
;..! "
}// 
catch00 
(00 
	Exception00 
)00 
{11 
return22 

StatusCode22 !
(22! "
$num22" %
,22% &
$str22' `
)22` a
;22a b
}33 
}44 	
[66 	
HttpPut66	 
(66 
$str66 
)66 
]66 
[77 	
	Authorize77	 
(77 
Roles77 
=77 
$str77 %
)77% &
]77& '
public88 
async88 
Task88 
<88 
IActionResult88 '
>88' (
RespondToAudit88) 7
(887 8
[888 9
FromBody889 A
]88A B
AuditResponseDto88C S
dto88T W
)88W X
{99 	
try:: 
{;; 
var<< 
userId<< 
=<< 
int<<  
.<<  !
Parse<<! &
(<<& '
User<<' +
.<<+ ,
FindFirstValue<<, :
(<<: ;

ClaimTypes<<; E
.<<E F
NameIdentifier<<F T
)<<T U
??<<V X
$str<<Y \
)<<\ ]
;<<] ^
var== 
success== 
=== 
await== # 
_auditRequestService==$ 8
.==8 9
RespondToAuditAsync==9 L
(==L M
dto==M P
,==P Q
userId==R X
)==X Y
;==Y Z
if?? 
(?? 
!?? 
success?? 
)?? 
return@@ 

BadRequest@@ %
(@@% &
$str@@& S
)@@S T
;@@T U
returnBB 
OkBB 
(BB 
$strBB B
)BBB C
;BBC D
}CC 
catchDD 
(DD 
	ExceptionDD 
)DD 
{EE 
returnFF 

StatusCodeFF !
(FF! "
$numFF" %
,FF% &
$strFF' a
)FFa b
;FFb c
}GG 
}HH 	
[JJ 	
HttpGetJJ	 
(JJ 
$strJJ 
)JJ 
]JJ 
[KK 	
	AuthorizeKK	 
(KK 
RolesKK 
=KK 
$strKK "
)KK" #
]KK# $
publicLL 
asyncLL 
TaskLL 
<LL 
IActionResultLL '
>LL' (
GetAllAuditRequestsLL) <
(LL< =
)LL= >
{MM 	
tryNN 
{OO 
varPP 
auditsPP 
=PP 
awaitPP " 
_auditRequestServicePP# 7
.PP7 8$
GetAllAuditRequestsAsyncPP8 P
(PPP Q
)PPQ R
;PPR S
returnQQ 
OkQQ 
(QQ 
auditsQQ  
)QQ  !
;QQ! "
}RR 
catchSS 
(SS 
	ExceptionSS 
)SS 
{TT 
returnUU 

StatusCodeUU !
(UU! "
$numUU" %
,UU% &
$strUU' [
)UU[ \
;UU\ ]
}VV 
}WW 	
}XX 
}YY »s
FD:\VSCodezz\AssetPortal\AssetManagement\Controllers\AssetController.cs
	namespace 	
AssetManagement
 
. 
Controllers %
{ 
[		 
Route		 

(		
 
$str		 
)		 
]		 
[

 
ApiController

 
]

 
public 

class 
AssetController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IAssetService &
_assetService' 4
;4 5
public 
AssetController 
( 
IAssetService ,
assetService- 9
)9 :
{ 	
_assetService 
= 
assetService (
;( )
} 	
[ 	
HttpPost	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
IActionResult '
>' (
CreateAsset) 4
(4 5
[5 6
FromBody6 >
]> ?
AssetCreateDto@ N
assetDtoO W
)W X
{ 	
try 
{ 
var 
assetId 
= 
await #
_assetService$ 1
.1 2
CreateAssetAsync2 B
(B C
assetDtoC K
)K L
;L M
if 
( 
assetId 
== 
$num  
)  !
return 

BadRequest %
(% &
new& )
{* +
error, 1
=2 3
$str4 M
}N O
)O P
;P Q
return 
Ok 
( 
new 
{ 
message  '
=( )
$str* F
,F G
assetIdH O
}P Q
)Q R
;R S
} 
catch   
(   
	Exception   
ex   
)    
{!! 
return"" 

StatusCode"" !
(""! "
$num""" %
,""% &
new""' *
{""+ ,
error""- 2
=""3 4
$str""5 M
,""M N
detail""O U
=""V W
ex""X Z
.""Z [
Message""[ b
}""c d
)""d e
;""e f
}## 
}$$ 	
[&& 	
HttpGet&&	 
]&& 
['' 	
	Authorize''	 
('' 
Roles'' 
='' 
$str'' "
)''" #
]''# $
public(( 
async(( 
Task(( 
<(( 
IActionResult(( '
>((' (
GetAll(() /
(((/ 0
)((0 1
{)) 	
try** 
{++ 
var,, 
assets,, 
=,, 
await,, "
_assetService,,# 0
.,,0 1
GetAllAssetsAsync,,1 B
(,,B C
),,C D
;,,D E
return-- 
Ok-- 
(-- 
assets--  
)--  !
;--! "
}.. 
catch// 
(// 
	Exception// 
ex// 
)//  
{00 
return11 

StatusCode11 !
(11! "
$num11" %
,11% &
new11' *
{11+ ,
error11- 2
=113 4
$str115 N
,11N O
detail11P V
=11W X
ex11Y [
.11[ \
Message11\ c
}11d e
)11e f
;11f g
}22 
}33 	
[55 	
HttpGet55	 
(55 
$str55 
)55 
]55 
[66 	
	Authorize66	 
(66 
Roles66 
=66 
$str66 "
)66" #
]66# $
public77 
async77 
Task77 
<77 
IActionResult77 '
>77' (
GetAssetById77) 5
(775 6
int776 9
assetId77: A
)77A B
{88 	
try99 
{:: 
var;; 
asset;; 
=;; 
await;; !
_assetService;;" /
.;;/ 0
GetAssetByIdAsync;;0 A
(;;A B
assetId;;B I
);;I J
;;;J K
if<< 
(<< 
asset<< 
==<< 
null<< !
)<<! "
return== 
NotFound== #
(==# $
new==$ '
{==( )
error==* /
===0 1
$str==2 D
}==E F
)==F G
;==G H
return?? 
Ok?? 
(?? 
asset?? 
)??  
;??  !
}@@ 
catchAA 
(AA 
	ExceptionAA 
exAA 
)AA  
{BB 
returnCC 

StatusCodeCC !
(CC! "
$numCC" %
,CC% &
newCC' *
{CC+ ,
errorCC- 2
=CC3 4
$strCC5 M
,CCM N
detailCCO U
=CCV W
exCCX Z
.CCZ [
MessageCC[ b
}CCc d
)CCd e
;CCe f
}DD 
}EE 	
[GG 	
HttpPutGG	 
(GG 
$strGG 
)GG 
]GG 
[HH 	
	AuthorizeHH	 
(HH 
RolesHH 
=HH 
$strHH "
)HH" #
]HH# $
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (
UpdateAssetII) 4
(II4 5
intII5 8
assetIdII9 @
,II@ A
[IIB C
FromBodyIIC K
]IIK L
AssetUpdateDtoIIM [
dtoII\ _
)II_ `
{JJ 	
tryKK 
{LL 
varMM 
updatedMM 
=MM 
awaitMM #
_assetServiceMM$ 1
.MM1 2
UpdateAssetAsyncMM2 B
(MMB C
assetIdMMC J
,MMJ K
dtoMML O
)MMO P
;MMP Q
ifNN 
(NN 
!NN 
updatedNN 
)NN 
returnOO 
NotFoundOO #
(OO# $
newOO$ '
{OO( )
errorOO* /
=OO0 1
$strOO2 D
}OOE F
)OOF G
;OOG H
returnQQ 
OkQQ 
(QQ 
newQQ 
{QQ 
messageQQ  '
=QQ( )
$strQQ* G
}QQH I
)QQI J
;QQJ K
}RR 
catchSS 
(SS 
	ExceptionSS 
exSS 
)SS  
{TT 
returnUU 

StatusCodeUU !
(UU! "
$numUU" %
,UU% &
newUU' *
{UU+ ,
errorUU- 2
=UU3 4
$strUU5 N
,UUN O
detailUUP V
=UUW X
exUUY [
.UU[ \
MessageUU\ c
}UUd e
)UUe f
;UUf g
}VV 
}WW 	
[YY 	

HttpDeleteYY	 
(YY 
$strYY 
)YY  
]YY  !
[ZZ 	
	AuthorizeZZ	 
(ZZ 
RolesZZ 
=ZZ 
$strZZ "
)ZZ" #
]ZZ# $
public[[ 
async[[ 
Task[[ 
<[[ 
IActionResult[[ '
>[[' (
DeleteAsset[[) 4
([[4 5
int[[5 8
assetId[[9 @
)[[@ A
{\\ 	
try]] 
{^^ 
var__ 
deleted__ 
=__ 
await__ #
_assetService__$ 1
.__1 2
DeleteAssetAsync__2 B
(__B C
assetId__C J
)__J K
;__K L
if`` 
(`` 
!`` 
deleted`` 
)`` 
returnaa 
NotFoundaa #
(aa# $
newaa$ '
{aa( )
erroraa* /
=aa0 1
$straa2 D
}aaE F
)aaF G
;aaG H
returncc 
Okcc 
(cc 
newcc 
{cc 
messagecc  '
=cc( )
$strcc* G
}ccH I
)ccI J
;ccJ K
}dd 
catchee 
(ee 
	Exceptionee 
exee 
)ee  
{ff 
returngg 

StatusCodegg !
(gg! "
$numgg" %
,gg% &
newgg' *
{gg+ ,
errorgg- 2
=gg3 4
$strgg5 N
,ggN O
detailggP V
=ggW X
exggY [
.gg[ \
Messagegg\ c
}ggd e
)gge f
;ggf g
}hh 
}ii 	
[kk 	
HttpGetkk	 
(kk 
$strkk &
)kk& '
]kk' (
[ll 	
	Authorizell	 
(ll 
Rolesll 
=ll 
$strll %
)ll% &
]ll& '
publicmm 
asyncmm 
Taskmm 
<mm 
ActionResultmm &
<mm& '
IEnumerablemm' 2
<mm2 3
AssetAvailableDtomm3 D
>mmD E
>mmE F
>mmF G
GetAvailableAssetsmmH Z
(mmZ [
)mm[ \
{nn 	
tryoo 
{pp 
varqq 
resultqq 
=qq 
awaitqq "
_assetServiceqq# 0
.qq0 1.
"GetAvailableAssetsForEmployeeAsyncqq1 S
(qqS T
)qqT U
;qqU V
returnrr 
Okrr 
(rr 
resultrr  
)rr  !
;rr! "
}ss 
catchtt 
(tt 
	Exceptiontt 
extt 
)tt  
{uu 
returnvv 

StatusCodevv !
(vv! "
$numvv" %
,vv% &
newvv' *
{vv+ ,
errorvv- 2
=vv3 4
$strvv5 X
,vvX Y
detailvvZ `
=vva b
exvvc e
.vve f
Messagevvf m
}vvn o
)vvo p
;vvp q
}ww 
}xx 	
[zz 	
HttpGetzz	 
(zz 
$strzz 
)zz 
]zz 
[{{ 	
	Authorize{{	 
({{ 
Roles{{ 
={{ 
$str{{ %
){{% &
]{{& '
public|| 
async|| 
Task|| 
<|| 
IActionResult|| '
>||' (
GetMyAssets||) 4
(||4 5
)||5 6
{}} 	
try~~ 
{ 
var
€€ 
userIdClaim
€€ 
=
€€  !
User
€€" &
.
€€& '
FindFirstValue
€€' 5
(
€€5 6

ClaimTypes
€€6 @
.
€€@ A
NameIdentifier
€€A O
)
€€O P
;
€€P Q
if
 
(
 
string
 
.
 
IsNullOrEmpty
 (
(
( )
userIdClaim
) 4
)
4 5
||
6 8
!
9 :
int
: =
.
= >
TryParse
> F
(
F G
userIdClaim
G R
,
R S
out
T W
var
X [
userId
\ b
)
b c
)
c d
return
‚‚ 
Unauthorized
‚‚ '
(
‚‚' (
new
‚‚( +
{
‚‚, -
error
‚‚. 3
=
‚‚4 5
$str
‚‚6 Q
}
‚‚R S
)
‚‚S T
;
‚‚T U
var
„„ 
assets
„„ 
=
„„ 
await
„„ "
_assetService
„„# 0
.
„„0 1/
!GetAssignedAssetsForEmployeeAsync
„„1 R
(
„„R S
userId
„„S Y
)
„„Y Z
;
„„Z [
return
…… 
Ok
…… 
(
…… 
assets
……  
)
……  !
;
……! "
}
†† 
catch
‡‡ 
(
‡‡ 
	Exception
‡‡ 
ex
‡‡ 
)
‡‡  
{
 
return
‰‰ 

StatusCode
‰‰ !
(
‰‰! "
$num
‰‰" %
,
‰‰% &
new
‰‰' *
{
‰‰+ ,
error
‰‰- 2
=
‰‰3 4
$str
‰‰5 W
,
‰‰W X
detail
‰‰Y _
=
‰‰` a
ex
‰‰b d
.
‰‰d e
Message
‰‰e l
}
‰‰m n
)
‰‰n o
;
‰‰o p
}
 
}
‹‹ 	
[
 	
HttpGet
	 
(
 
$str
 *
)
* +
]
+ ,
[
 	
	Authorize
	 
(
 
Roles
 
=
 
$str
 %
)
% &
]
& '
public
 
async
 
Task
 
<
 
IActionResult
 '
>
' (%
GetAssetByIdForEmployee
) @
(
@ A
int
A D
assetId
E L
)
L M
{
 	
try
‘‘ 
{
’’ 
var
““ 
asset
““ 
=
““ 
await
““ !
_assetService
““" /
.
““/ 0
GetAssetByIdAsync
““0 A
(
““A B
assetId
““B I
)
““I J
;
““J K
if
”” 
(
”” 
asset
”” 
==
”” 
null
”” !
)
””! "
return
•• 
NotFound
•• #
(
••# $
new
••$ '
{
••( )
error
••* /
=
••0 1
$str
••2 D
}
••E F
)
••F G
;
••G H
var
—— 
dto
—— 
=
—— 
new
—— 
{
 
asset
™™ 
.
™™ 
AssetId
™™ !
,
™™! "
asset
 
.
 
	AssetName
 #
,
# $
asset
›› 
.
›› 
CategoryName
›› &
,
››& '
asset
 
.
 

AssetModel
 $
,
$ %
asset
 
.
 
Quantity
 "
,
" #
asset
 
.
 
ImageUrl
 "
,
" #
asset
 
.
 
ManufacturingDate
 +
,
+ ,
asset
   
.
   

ExpiryDate
   $
,
  $ %
asset
΅΅ 
.
΅΅ 
Status
΅΅  
}
ΆΆ 
;
ΆΆ 
return
¤¤ 
Ok
¤¤ 
(
¤¤ 
dto
¤¤ 
)
¤¤ 
;
¤¤ 
}
¥¥ 
catch
¦¦ 
(
¦¦ 
	Exception
¦¦ 
ex
¦¦ 
)
¦¦  
{
§§ 
return
¨¨ 

StatusCode
¨¨ !
(
¨¨! "
$num
¨¨" %
,
¨¨% &
new
¨¨' *
{
¨¨+ ,
error
¨¨- 2
=
¨¨3 4
$str
¨¨5 M
,
¨¨M N
detail
¨¨O U
=
¨¨V W
ex
¨¨X Z
.
¨¨Z [
Message
¨¨[ b
}
¨¨c d
)
¨¨d e
;
¨¨e f
}
©© 
}
ªª 	
}
«« 
}¬¬ Ι’
PD:\VSCodezz\AssetPortal\AssetManagement\Controllers\AssetAssignmentController.cs
	namespace		 	
AssetManagement		
 
.		 
Controllers		 %
{

 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class %
AssetAssignmentController *
:+ ,
ControllerBase- ;
{ 
private 
readonly #
IAssetAssignmentService 0#
_assetAssignmentService1 H
;H I
public %
AssetAssignmentController (
(( )#
IAssetAssignmentService) @"
assetAssignmentServiceA W
)W X
{ 	#
_assetAssignmentService #
=$ %"
assetAssignmentService& <
;< =
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
	Authorize	 
] 
public 
async 
Task 
< 
IActionResult '
>' (
RequestAsset) 5
(5 6
[6 7
FromBody7 ?
]? @
AssetRequestDtoA P

requestDtoQ [
)[ \
{ 	
try 
{ 
var 
userIdString  
=! "
User# '
.' (
FindFirstValue( 6
(6 7

ClaimTypes7 A
.A B
NameIdentifierB P
)P Q
;Q R
if 
( 
! 
int 
. 
TryParse !
(! "
userIdString" .
,. /
out0 3
var4 7
userId8 >
)> ?
)? @
return 
Unauthorized '
(' (
new( +
{, -
error. 3
=4 5
$str6 H
}I J
)J K
;K L
var   
result   
=   
await   "#
_assetAssignmentService  # :
.  : ;
RequestAssetAsync  ; L
(  L M
userId  M S
,  S T

requestDto  U _
)  _ `
;  ` a
return!! 
Ok!! 
(!! 
new!! 
{!! 
message!!  '
=!!( )
result!!* 0
}!!1 2
)!!2 3
;!!3 4
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 

BadRequest%% !
(%%! "
new%%" %
{%%& '
error%%( -
=%%. /
ex%%0 2
.%%2 3
Message%%3 :
}%%; <
)%%< =
;%%= >
}&& 
}'' 	
[)) 	
HttpPost))	 
()) 
$str)) 
))) 
])) 
[** 	
	Authorize**	 
(** 
Roles** 
=** 
$str** "
)**" #
]**# $
public++ 
async++ 
Task++ 
<++ 
IActionResult++ '
>++' (
AssignAsset++) 4
(++4 5
[++5 6
FromBody++6 >
]++> ?
AssetAssignInputDto++@ S
dto++T W
)++W X
{,, 	
try-- 
{.. 
var// 
message// 
=// 
await// ##
_assetAssignmentService//$ ;
.//; <
AssignAssetAsync//< L
(//L M
dto//M P
)//P Q
;//Q R
return00 
Ok00 
(00 
new00 
{00 
message00  '
}00( )
)00) *
;00* +
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
return44 

StatusCode44 !
(44! "
$num44" %
,44% &
new44' *
{44+ ,
error44- 2
=443 4
$str445 N
,44N O
detail44P V
=44W X
ex44Y [
.44[ \
Message44\ c
}44d e
)44e f
;44f g
}55 
}66 	
[88 	
HttpPost88	 
(88 
$str88 1
)881 2
]882 3
[99 	
	Authorize99	 
(99 
Roles99 
=99 
$str99 %
)99% &
]99& '
public:: 
async:: 
Task:: 
<:: 
IActionResult:: '
>::' (
RequestReturn::) 6
(::6 7
int::7 :
assignmentId::; G
)::G H
{;; 	
try<< 
{== 
var>> 
employeeIdString>> $
=>>% &
User>>' +
.>>+ ,
FindFirstValue>>, :
(>>: ;

ClaimTypes>>; E
.>>E F
NameIdentifier>>F T
)>>T U
;>>U V
if?? 
(?? 
!?? 
int?? 
.?? 
TryParse?? !
(??! "
employeeIdString??" 2
,??2 3
out??4 7
var??8 ;

employeeId??< F
)??F G
)??G H
return@@ 
Unauthorized@@ '
(@@' (
new@@( +
{@@, -
success@@. 5
=@@6 7
false@@8 =
,@@= >
message@@? F
=@@G H
$str@@I _
}@@` a
)@@a b
;@@b c
varBB 
resultBB 
=BB 
awaitBB "#
_assetAssignmentServiceBB# :
.BB: ;
RequestReturnAsyncBB; M
(BBM N
assignmentIdBBN Z
,BBZ [

employeeIdBB\ f
)BBf g
;BBg h
returnCC 
OkCC 
(CC 
newCC 
{CC 
successCC  '
=CC( )
trueCC* .
,CC. /
messageCC0 7
=CC8 9
resultCC: @
}CCA B
)CCB C
;CCC D
}DD 
catchEE 
(EE #
BadHttpRequestExceptionEE *
exEE+ -
)EE- .
{FF 
returnGG 

BadRequestGG !
(GG! "
newGG" %
{GG& '
successGG( /
=GG0 1
falseGG2 7
,GG7 8
messageGG9 @
=GGA B
exGGC E
.GGE F
MessageGGF M
}GGN O
)GGO P
;GGP Q
}HH 
catchII 
(II 
	ExceptionII 
exII 
)II  
{JJ 
returnKK 

StatusCodeKK !
(KK! "
$numKK" %
,KK% &
newKK' *
{KK+ ,
successKK- 4
=KK5 6
falseKK7 <
,KK< =
messageKK> E
=KKF G
$strKKH Z
,KKZ [
detailKK\ b
=KKc d
exKKe g
.KKg h
MessageKKh o
}KKp q
)KKq r
;KKr s
}LL 
}MM 	
[OO 	
HttpGetOO	 
(OO 
$strOO "
)OO" #
]OO# $
[PP 	
	AuthorizePP	 
(PP 
RolesPP 
=PP 
$strPP "
)PP" #
]PP# $
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
IActionResultQQ '
>QQ' (
GetReturnRequestsQQ) :
(QQ: ;
)QQ; <
{RR 	
trySS 
{TT 
varUU 
returnRequestsUU "
=UU# $
awaitUU% *#
_assetAssignmentServiceUU+ B
.UUB C%
GetAllReturnRequestsAsyncUUC \
(UU\ ]
)UU] ^
;UU^ _
returnVV 
OkVV 
(VV 
returnRequestsVV (
)VV( )
;VV) *
}WW 
catchXX 
(XX 
	ExceptionXX 
exXX 
)XX  
{YY 
returnZZ 

StatusCodeZZ !
(ZZ! "
$numZZ" %
,ZZ% &
newZZ' *
{ZZ+ ,
errorZZ- 2
=ZZ3 4
$strZZ5 W
,ZZW X
detailZZY _
=ZZ` a
exZZb d
.ZZd e
MessageZZe l
}ZZm n
)ZZn o
;ZZo p
}[[ 
}\\ 	
[^^ 	
HttpPost^^	 
(^^ 
$str^^ 1
)^^1 2
]^^2 3
[__ 	
	Authorize__	 
(__ 
Roles__ 
=__ 
$str__ "
)__" #
]__# $
public`` 
async`` 
Task`` 
<`` 
IActionResult`` '
>``' (
ApproveReturn``) 6
(``6 7
int``7 :
assignmentId``; G
)``G H
{aa 	
trybb 
{cc 
vardd 
resultdd 
=dd 
awaitdd "#
_assetAssignmentServicedd# :
.dd: ;
ApproveReturnAsyncdd; M
(ddM N
assignmentIdddN Z
)ddZ [
;dd[ \
returnee 
Okee 
(ee 
newee 
{ee 
messageee  '
=ee( )
resultee* 0
}ee1 2
)ee2 3
;ee3 4
}ff 
catchgg 
(gg 
	Exceptiongg 
exgg 
)gg  
{hh 
returnii 

StatusCodeii !
(ii! "
$numii" %
,ii% &
newii' *
{ii+ ,
errorii- 2
=ii3 4
$strii5 P
,iiP Q
detailiiR X
=iiY Z
exii[ ]
.ii] ^
Messageii^ e
}iif g
)iig h
;iih i
}jj 
}kk 	
[mm 	
HttpGetmm	 
(mm 
$strmm "
)mm" #
]mm# $
[nn 	
	Authorizenn	 
(nn 
Rolesnn 
=nn 
$strnn "
)nn" #
]nn# $
publicoo 
asyncoo 
Taskoo 
<oo 
IActionResultoo '
>oo' (
GetPendingRequestsoo) ;
(oo; <
)oo< =
{pp 	
tryqq 
{rr 
varss 
requestsss 
=ss 
awaitss $#
_assetAssignmentServicess% <
.ss< =&
GetAllPendingRequestsAsyncss= W
(ssW X
)ssX Y
;ssY Z
returntt 
Oktt 
(tt 
requeststt "
)tt" #
;tt# $
}uu 
catchvv 
(vv 
	Exceptionvv 
exvv 
)vv  
{ww 
returnxx 

StatusCodexx !
(xx! "
$numxx" %
,xx% &
newxx' *
{xx+ ,
errorxx- 2
=xx3 4
$strxx5 X
,xxX Y
detailxxZ `
=xxa b
exxxc e
.xxe f
Messagexxf m
}xxn o
)xxo p
;xxp q
}yy 
}zz 	
[|| 	
HttpPost||	 
(|| 
$str|| )
)||) *
]||* +
[}} 	
	Authorize}}	 
(}} 
Roles}} 
=}} 
$str}} "
)}}" #
]}}# $
public~~ 
async~~ 
Task~~ 
<~~ 
IActionResult~~ '
>~~' (
RejectRequest~~) 6
(~~6 7
int~~7 :
assignmentId~~; G
)~~G H
{ 	
try
€€ 
{
 
var
‚‚ 
result
‚‚ 
=
‚‚ 
await
‚‚ "%
_assetAssignmentService
‚‚# :
.
‚‚: ; 
RejectRequestAsync
‚‚; M
(
‚‚M N
assignmentId
‚‚N Z
)
‚‚Z [
;
‚‚[ \
return
ƒƒ 
Ok
ƒƒ 
(
ƒƒ 
new
ƒƒ 
{
ƒƒ 
message
ƒƒ  '
=
ƒƒ( )
result
ƒƒ* 0
}
ƒƒ1 2
)
ƒƒ2 3
;
ƒƒ3 4
}
„„ 
catch
…… 
(
…… 
	Exception
…… 
ex
…… 
)
……  
{
†† 
return
‡‡ 

StatusCode
‡‡ !
(
‡‡! "
$num
‡‡" %
,
‡‡% &
new
‡‡' *
{
‡‡+ ,
error
‡‡- 2
=
‡‡3 4
$str
‡‡5 P
,
‡‡P Q
detail
‡‡R X
=
‡‡Y Z
ex
‡‡[ ]
.
‡‡] ^
Message
‡‡^ e
}
‡‡f g
)
‡‡g h
;
‡‡h i
}
 
}
‰‰ 	
[
‹‹ 	
HttpPost
‹‹	 
(
‹‹ 
$str
‹‹ 0
)
‹‹0 1
]
‹‹1 2
[
 	
	Authorize
	 
(
 
Roles
 
=
 
$str
 "
)
" #
]
# $
public
 
async
 
Task
 
<
 
IActionResult
 '
>
' (
RejectReturn
) 5
(
5 6
int
6 9
assignmentId
: F
)
F G
{
 	
try
 
{
 
var
‘‘ 
result
‘‘ 
=
‘‘ 
await
‘‘ "%
_assetAssignmentService
‘‘# :
.
‘‘: ;&
RejectReturnRequestAsync
‘‘; S
(
‘‘S T
assignmentId
‘‘T `
)
‘‘` a
;
‘‘a b
return
’’ 
Ok
’’ 
(
’’ 
new
’’ 
{
’’ 
message
’’  '
=
’’( )
result
’’* 0
}
’’1 2
)
’’2 3
;
’’3 4
}
““ 
catch
”” 
(
”” 
	Exception
”” 
ex
”” 
)
””  
{
•• 
return
–– 

StatusCode
–– !
(
––! "
$num
––" %
,
––% &
new
––' *
{
––+ ,
error
––- 2
=
––3 4
$str
––5 W
,
––W X
detail
––Y _
=
––` a
ex
––b d
.
––d e
Message
––e l
}
––m n
)
––n o
;
––o p
}
—— 
}
 	
[
 	
HttpGet
	 
(
 
$str
 &
)
& '
]
' (
[
›› 	
	Authorize
››	 
(
›› 
Roles
›› 
=
›› 
$str
›› "
)
››" #
]
››# $
public
 
async
 
Task
 
<
 
IActionResult
 '
>
' ("
GetAllAssignedAssets
) =
(
= >
)
> ?
{
 	
try
 
{
 
var
   
result
   
=
   
await
   "%
_assetAssignmentService
  # :
.
  : ;'
GetAllAssignedAssetsAsync
  ; T
(
  T U
)
  U V
;
  V W
return
΅΅ 
Ok
΅΅ 
(
΅΅ 
result
΅΅  
)
΅΅  !
;
΅΅! "
}
ΆΆ 
catch
££ 
(
££ 
	Exception
££ 
ex
££ 
)
££  
{
¤¤ 
return
¥¥ 

StatusCode
¥¥ !
(
¥¥! "
$num
¥¥" %
,
¥¥% &
new
¥¥' *
{
¥¥+ ,
error
¥¥- 2
=
¥¥3 4
$str
¥¥5 W
,
¥¥W X
detail
¥¥Y _
=
¥¥` a
ex
¥¥b d
.
¥¥d e
Message
¥¥e l
}
¥¥m n
)
¥¥n o
;
¥¥o p
}
¦¦ 
}
§§ 	
[
©© 	
HttpGet
©©	 
(
©© 
$str
©© $
)
©©$ %
]
©©% &
[
ªª 	
	Authorize
ªª	 
(
ªª 
Roles
ªª 
=
ªª 
$str
ªª "
)
ªª" #
]
ªª# $
public
«« 
async
«« 
Task
«« 
<
«« 
IActionResult
«« '
>
««' (!
GetRejectedRequests
««) <
(
««< =
)
««= >
{
¬¬ 	
try
­­ 
{
®® 
var
―― 
result
―― 
=
―― 
await
―― "%
_assetAssignmentService
――# :
.
――: ;)
GetAllRejectedRequestsAsync
――; V
(
――V W
)
――W X
;
――X Y
return
°° 
Ok
°° 
(
°° 
result
°°  
)
°°  !
;
°°! "
}
±± 
catch
²² 
(
²² 
	Exception
²² 
ex
²² 
)
²²  
{
³³ 
return
΄΄ 

StatusCode
΄΄ !
(
΄΄! "
$num
΄΄" %
,
΄΄% &
new
΄΄' *
{
΄΄+ ,
error
΄΄- 2
=
΄΄3 4
$str
΄΄5 Y
,
΄΄Y Z
detail
΄΄[ a
=
΄΄b c
ex
΄΄d f
.
΄΄f g
Message
΄΄g n
}
΄΄o p
)
΄΄p q
;
΄΄q r
}
µµ 
}
¶¶ 	
[
·· 	
HttpGet
··	 
(
·· 
$str
·· 
)
·· 
]
·· 
[
ΈΈ 	
	Authorize
ΈΈ	 
(
ΈΈ 
Roles
ΈΈ 
=
ΈΈ 
$str
ΈΈ %
)
ΈΈ% &
]
ΈΈ& '
public
ΉΉ 
async
ΉΉ 
Task
ΉΉ 
<
ΉΉ 
IActionResult
ΉΉ '
>
ΉΉ' (
GetMyAssets
ΉΉ) 4
(
ΉΉ4 5
)
ΉΉ5 6
{
ΊΊ 	
try
»» 
{
ΌΌ 
var
½½ 
userIdString
½½  
=
½½! "
User
½½# '
.
½½' (
FindFirstValue
½½( 6
(
½½6 7

ClaimTypes
½½7 A
.
½½A B
NameIdentifier
½½B P
)
½½P Q
;
½½Q R
if
ΎΎ 
(
ΎΎ 
!
ΎΎ 
int
ΎΎ 
.
ΎΎ 
TryParse
ΎΎ !
(
ΎΎ! "
userIdString
ΎΎ" .
,
ΎΎ. /
out
ΎΎ0 3
var
ΎΎ4 7
userId
ΎΎ8 >
)
ΎΎ> ?
)
ΎΎ? @
return
ΏΏ 
Unauthorized
ΏΏ '
(
ΏΏ' (
new
ΏΏ( +
{
ΏΏ, -
error
ΏΏ. 3
=
ΏΏ4 5
$str
ΏΏ6 H
}
ΏΏI J
)
ΏΏJ K
;
ΏΏK L
var
ΑΑ 
result
ΑΑ 
=
ΑΑ 
await
ΑΑ "%
_assetAssignmentService
ΑΑ# :
.
ΑΑ: ;
GetMyAssetsAsync
ΑΑ; K
(
ΑΑK L
userId
ΑΑL R
)
ΑΑR S
;
ΑΑS T
return
ΒΒ 
Ok
ΒΒ 
(
ΒΒ 
result
ΒΒ  
)
ΒΒ  !
;
ΒΒ! "
}
ΓΓ 
catch
ΔΔ 
(
ΔΔ 
	Exception
ΔΔ 
ex
ΔΔ 
)
ΔΔ  
{
ΕΕ 
return
ΖΖ 

StatusCode
ΖΖ !
(
ΖΖ! "
$num
ΖΖ" %
,
ΖΖ% &
new
ΖΖ' *
{
ΖΖ+ ,
error
ΖΖ- 2
=
ΖΖ3 4
$str
ΖΖ5 S
,
ΖΖS T
detail
ΖΖU [
=
ΖΖ\ ]
ex
ΖΖ^ `
.
ΖΖ` a
Message
ΖΖa h
}
ΖΖi j
)
ΖΖj k
;
ΖΖk l
}
ΗΗ 
}
ΘΘ 	
}
ΙΙ 
}ΚΚ ω
GD:\VSCodezz\AssetPortal\AssetManagement\Context\ApplicationDbContext.cs
	namespace 	
AssetManagement
 
. 
Context !
{ 
public 

class  
ApplicationDbContext %
:& '
	DbContext( 1
{ 
public  
ApplicationDbContext #
(# $
DbContextOptions$ 4
<4 5 
ApplicationDbContext5 I
>I J
optionsK R
)R S
:T U
baseV Z
(Z [
options[ b
)b c
{		 	
}

 	
public 
DbSet 
< 
User 
> 
Users  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
public 
DbSet 
< 
Role 
> 
Roles  
{! "
get# &
;& '
set( +
;+ ,
}- .
=/ 0
null1 5
!5 6
;6 7
public 
DbSet 
< 
AssetCategory "
>" #
AssetCategories$ 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
=B C
nullD H
!H I
;I J
public 
DbSet 
< 
Asset 
> 
Assets "
{# $
get% (
;( )
set* -
;- .
}/ 0
=1 2
null3 7
!7 8
;8 9
public 
DbSet 
< 
AssetAssignment $
>$ %
AssetAssignments& 6
{7 8
get9 <
;< =
set> A
;A B
}C D
=E F
nullG K
!K L
;L M
public 
DbSet 
< 
ServiceRequest #
># $
ServiceRequests% 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
=C D
nullE I
!I J
;J K
public 
DbSet 
< 

AssetAudit 
>  
AssetAudits! ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
=; <
null= A
!A B
;B C
	protected 
override 
void 
OnModelCreating  /
(/ 0
ModelBuilder0 <
modelBuilder= I
)I J
{ 	
base 
. 
OnModelCreating  
(  !
modelBuilder! -
)- .
;. /
modelBuilder 
. 
Entity 
<  
Asset  %
>% &
(& '
)' (
. 
Property 
( 
a 
=> 
a  
.  !

AssetValue! +
)+ ,
. 
HasPrecision 
( 
$num  
,  !
$num" #
)# $
;$ %
} 	
} 
} 