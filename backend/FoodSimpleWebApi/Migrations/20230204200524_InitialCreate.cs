using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodSimpleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficult = table.Column<int>(type: "int", nullable: false),
                    UserDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Users_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Count = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    RecipeDtoId = table.Column<int>(type: "int", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Recipes_RecipeDtoId",
                        column: x => x.RecipeDtoId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Users_UserDtoId",
                        column: x => x.UserDtoId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Count", "Name", "RecipeDtoId", "Unit", "UserDtoId" },
                values: new object[,]
                {
                    { 1, 8, "5", "CWTVSPDVWW", null, 2, null },
                    { 2, 1, "4", "KLJBHVANYH", null, 1, null },
                    { 3, 6, "6", "SKJVUSKACF", null, 2, null },
                    { 4, 5, "6", "IGABLJQTCY", null, 2, null },
                    { 5, 5, "5", "NAISCEREIT", null, 0, null },
                    { 6, 6, "9", "SLGDQYSUTK", null, 2, null },
                    { 7, 6, "8", "ZFZXWJKVCF", null, 2, null },
                    { 8, 5, "3", "QYGJQNJGDU", null, 1, null },
                    { 9, 8, "5", "SOVRZRQWVO", null, 1, null },
                    { 10, 3, "3", "OYFFRWSFHX", null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Difficult", "Name", "UserDtoId" },
                values: new object[,]
                {
                    { 1, "OKDAPBBBRJXJEXWOHQTOMHKDEHKKOXBLTPUBUQKSTCVEYTXBEXMCDATLCMACCPUXQYQIGUALQBWPGZXEUSRPRPUSFHYALKBLOLKPWIDFEYXUTVTMUUJTTYJGCDLZLKHBZFVLNIVLEGFUFOVFWIIIBUVCTJZDFBZCQWIMXVRZTYGPLXSFEVNUGQWVDGSKIROQPTLEGRUVMRIVAASSYANVCVKYUEMPNDGMMQZNYZSJKQOYCFPMLSHJTPFRQQPSTJQINWRBNRGYSRRQWTKFOFRDARWHSJEORCDULCZTMASZFVYKQYJMXFWTKUPWHHHDLULXKOOWCKMOKMEPINHNXIXUKQXSAOAHIQWMKYEXTFGOGPYFMAVMXOUZWDIIUVCFXINLHPZCIHXBLGRWKZFWPBWSJWJDKHWNDCSEVACHTTLCBYFKRGZCHYHPTSMSPRZWODZGSPZSKVLYCZYFEPSPJIRQRVMTFBKDYUQNKXITHCAVLEKVVOFTVQDW", 1, "DPMKVUYLVA", null },
                    { 2, "SWYOLARKISRVLAMNOLIVGQWYCHOEIILJXPMZOGVQULZMMAJWBAPQTZBLMOKTAINILWOEIFNYFHOCDSTSLGMLMSOHBESXFGKJASCYBZINUNTMNHYSRVLPJUOEHDDYPWFSCTJTKXXJXRREICUVFPDFVSPUXLKAXUHRNIIYXENRHRCXHZXABNORXIBMBDBQZDATKSXARHYYNKLRKHXNXSCZXGCNZEZVUEUCIZPVMHYVZQDYQTFOHELCDFIOZQIJBWSUULNEUDAEHTKMXKLLHRVTBSVGAUNUWBAPNLTCODJAEYKHRFYYKAJQRKVGXYBCSBENPDISIIZEINSLWYUDQKQEKTWNTGEQMADDHJXNKBXHCKPNNKKOMHNMGEFKLDUPGVKPELGUPMAKWTWLGBQCXLQVSWWQQAWCXWXVISAITIFIBDYYPKKSNSIEOJEIMQWAKNRAZBKCRVTYUDPHZQRWKTVXURGQAXTYXAHLWPXUTGJCEZMSIRUZQVCN", 3, "MVQOBEXPVK", null },
                    { 3, "HVEGAIDHSFJCPRIKLHEAYPLBFAFEBWUNBRSSICMJGKAIUUJADYREDNNMAKWAHRZGTMYZFIAXBRXPXXRHKUVNPYMIONCDFWFTHXRUFSOLOSZPDTFQPWHSDNOZJTMAUURUQCCVBTESBEEJRSPLUAKPUZNVJQEGGSTDFURIRUTGHNDDZCGCDNOJXPVSZXPSMQFXEETPQDCCTKSZZVIUFLOSRCUNXKXPNKRNPMAVUUCYMEEIVJSXUYFBWUZXQJIHDMEQNAMEUWDHJRMVHCNJQDSCWNPWVCQAYVEMBLYFJDVSIJKFZUVPBZKBCNYICJHTNEATUFERTQHSZTEBATNHQNYXHYQRSCVLENYONEJJNHOJEEUVQIFZANNOBCFHQIQWRPEHUYMNAAHPJQVFXGIQNXSNSPMATXPJZHFKKSQQXORTDTJGSDNOYMOYMFSOJZIMBPHOOSFIURZPTJHCCXCTATJECLWAZVOEXLSNQGVEADIAQKWYQWRNRANY", 1, "PJXJCZOLPY", null },
                    { 4, "WWKLLIDGPQVWRHNXSZPFGTCNZTECAJNYEMHFMLYAJQEFLPNWMEGKDKWYDFHZXOHWUFILRHURSIGWJFJXVODYICWMSZIGNTJHFJRCOEJKLQYSDGOPWTCRMIUTCCSPZUYOZRWDBFBPMMDXZTSEPCKYEFMJDOTJJMREHJLIJOBWEHSNZLCGVXSGNRICUQPBPKBASWETICABUVICIOMGWQWYPUSUOYWJNZITSYMFJKYPYSXTEKMVHHHTKIMJLHFLEHUPFDUVMYJNTVFESAGHUWKRIPMOLYWFMSRTOVXPOZOTPVTGVEREWXEPQBPDFZQOEOYCAYTOXLOPKKQCLIPXNWVSRUYJOWPGGECDCFVENDSWZLMNSZCRHQWDBKUNRGFTERLEXSRYHSVGQESVNKSBVDZQNETXEODIDOIUOOELRAEHJFDAZUOHWWKDBRBHZCFSVRZODLLGYAIALREAUEDSLALBMPEPBIKOQBQGPGUCLKUVBWXUCMWHAKRV", 3, "WKSBLTNCDJ", null },
                    { 5, "BNIMDHYPMUUBWNGOPOGMSBWKSEZHCKVWWJZWNGSALTPGVGJIFMKAQAGFVSWLDMAPQARZYAUVIHCKOAWZSISDTRYDRVOFKAUGCVXSRDUAUPZMXJQYFFXAHYJPBZWEUIBXUEXGSSDYZUZKVVVATRXMEZRAUNZAGYHIPKMJKKHRHPWFPIIPTCIPOYKTUTGCPCVFVKHZEXGIDOVJHCQHXEPBNSPISIQZJGYEMGALLNALNTNIJENZIKCOBMKPRVCZUERUJLNPAGPQGYVITNFWQNEVMQRGAEYLMUTOJIZMJOXBDCURUFMFODOSIBVBKJKTACHHSONHCPOOSBHSPKEDFTMIUBGKASMTZXMNFHSVQZSJIVARTHYEGZEBXFXOUQFATFVXEHPNVJLKTPBPIFJOUIEAOXZVGKKPMAHBSWQAUHQITKQWORRIGBAFBKGGLPWTRJMEBNUJCMCWDKFNSYATEAMKZSZLLHZFWNLTHRJNRYKUMNXZYMBMJBTF", 1, "RSXVZJCSHM", null },
                    { 6, "PTONVLNIIQWZOLHAXTQTWBJAWGYJLCXZRJOMEWDNXBAIUHUPRDTSPVTXTCFXVBNTAZBTSKFPKYEGNCQRTUWHPJZBBRYNEVWXTMGVTUDDCWCDSEEXXMRQPGGTZFVSASTJJMTEDUVIDXIYRLVWOCYZTXCWYYPDEAFFGKMPHXKQCBYHNQECEIPZTKXGYKETDTUKGTEVLDCRSIJJBDTLLTKDEJJJBNOQMHHKZJXNYABCMLNAJKHCCLPMNWMTNMBTTMYMMBRHMOEZNGFVHQLBDADWULRTHYQSDXBSSSDLDANGPCEYXLUHWKRVOXXEYYWPYFMDFIWUSTWIUAFGQEAJCZSTLUEWREXGFMPAXJVXEIDJCSIUYQOLYVRQIRXYCKMYZGTNBYRHDUOATKZSBBKTMMJVQHYDXPBEEOJORLZXSZEXOCDMATGDNIUNSLLEPJBLVHRVSOYYWDPCKHXXDCCRQWLGYGAEKSKGRAVTXXBEUEBUMWLRAGEUSNEZ", 3, "QYSGSDMBRZ", null },
                    { 7, "IDQCJNCDRCBXZXVNGLWLYSKLUXXZDTLBBXLHRTDSNGMYGIKUNWFESRAHTATJZLCZYFYEIFSXAKUXUYIPTWLFAPLKDSIRYLWZCEHLLLFDWCIKLNJAZFHMHIFXGWYOJSSQLFJIYPGXNTRYKLCRQJCWVJWPZASNEDCPIYGZARVLPNSUUSJIYERWRCCSZJEHGULCMZRQIUGBPXBVQLHQBLOYGUZMPQFFBXYVLIOTMWCYRVZKNITNNAQLTUWSTSMLEOBXGCEYQXHVTEAFFYVQIFHMRQEBLIPBUTTNYPPGRMLLSXNNLGIVYRRURXFCWDKVZKPXWGGRQVUMQUHGWPSECYODNALKSDWZLGNTQVQXJJYMYFKPEATWQAJZGVAOSRAYTGXYSQXQCRJCKDPTEELFCUDXCIEAZDFZBBRVUNQSAIORQYPWRKWDXGIIPRKJQXQUNKPAKEMYBVWCPHGLOOREPYXZGZKASPWEKQOXFSCFLMLXRNGYUTPAHMWT", 3, "SHKURUABGR", null },
                    { 8, "NDGQMQBEZVYUGTYNRQOAWTFDGZWGVQUPQPJUUCYGLSIJFPFMFSIWAGTXEXZULXRTPGKDVRKFEFFTOICELVNPVEARUAGLSHREQLUERAXPKKPFYLJNOYDRUHFZQECWFPPDPTPXYJFRZGXEVQLXAJJTDZDVVWNSHDDEYLREPTJUFPOVRZOFCJRMQKGIFAXECMPRVHSDESBEMELSSPUVNYQTXQFEEEFUNWTVZMBPYJWXSFQMSSYWXCRKIQELJOOITTUKJEJSWXIELLAPAJCGGNSXJTHPGURMGCQFSKMQWZZNWRSMBNIOIGTDECQALWZGJLSYEDBYEOEXQJUVNDRLTLXOCJNSPBOTASRUJZPBRSMSACSFAPMSSRVSTTWUAYGBWTHIKFXAJSZQVHROWQWULTYWKGNNCHUFWPMHUJIPLGWYCNTEDIDEOELMSNEFIVRKKMVHFHWWKOJVODOZITBPIYJIHRKAIOKNZXNYPLNFTKKAXPCIURJHTWAV", 1, "PKOUCXBGXD", null },
                    { 9, "HHEKRPGLIPGCMLJNRXCLKZSXYTGNIZWSUTLXPTBZZKIQLWQJCUHZNUMDGHOCUUQBPPYOIOKSRIAVZCGTPFFHQFAILNVRGSQILMMIMFEODHIFXPRRDTVKFJZJWXWOYLOKNBZRJOZRKGOIKHYMRISYYAOCCEBJEVCCLTGRTYVNRPCOPKWDGJFTPJYVICNZEWWNNHEEMFGRTLVQLSNWTXFOCZJRPZOCYOYMFZFHOUNTFEBDDAADCHDKZFFDGFHGKATXFIIJEQXUCZITPLSNDUHRJDEGXESWBRBOFJNXNVFBIGMWYSCFYUAWLBTHBYOXDQXFIQZFAKPDABNRELYISUOVUGHCCGTOTQBVMILTLQPJWMGIYJHRDJGKVAXXJMPAKQLQBFPSDNYZXZCYERRXEJKSXKBMZSMOUGTCPCTNZCAYHLTYLTWNRBALFXMKJJNEYLDTNGGYSWDCFFBRRLIIPDSBPXQYUXTGCDWZNHXDKXXVQEQGAMTUIQKC", 1, "QULJMLPFPW", null },
                    { 10, "IJXDQRXZXDSOWVXSOYYHIYRJIUQSDGUAUWTFLCPZFDJRNWRSESPPDCUJFMENBCFBBIEQRSGNOAJTVEBHIUWJVNADRVVJJNUBEVLYBNEOPQDNLHMSQQKSRZTYTUTEKLBQPDFCQRCZGFNXGTUOATUWVGKLKPLMFTPYGMCXZNJPNVDBJFWMNFQDKDMHHOLTQTXKLXYCRMMIUBNFVUZHNTCDAPMRBTDYYYJHSNHFVTNKHOSNYPJPOIYBLPZFXQLFIFSSLFMEHETZPUBYUNDOZRHFUSXZLGRHWBOHBFJOXHDHQUCYKTUMPDUFVKTYNVIDICVEVXJMKGRJXKLYNFJFQJZQQBNISAEMAUKLAYQKIWHALRNDWCVBLLNMHRMNCAKKKWVACEGTFXZIAHKFWVZGBZOAHNUQYLQHDRXEABOVPFFVZLBBBHDKWKURMBBASANJMONAXRJSNRBBCRXCMILYOUBYJGCJFHSUZSNNYNNLNNMZUWLBRVONNRQY", 2, "NKXLCBMWYK", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email" },
                values: new object[,]
                {
                    { 1, "ASYDXXY@gmail.com" },
                    { 2, "KPODLQG@gmail.com" },
                    { 3, "BCZANZJ@gmail.com" },
                    { 4, "SOJNWQW@gmail.com" },
                    { 5, "ZFNGCOD@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_RecipeDtoId",
                table: "Products",
                column: "RecipeDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserDtoId",
                table: "Products",
                column: "UserDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserDtoId",
                table: "Recipes",
                column: "UserDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
