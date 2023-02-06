﻿// <auto-generated />
using System;
using FoodSimpleWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodSimpleWebApi.Migrations
{
    [DbContext(typeof(FoodSimpleDbContext))]
    [Migration("20230206213055_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RecipeDtoId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeDtoId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Sweet",
                            Count = "1",
                            Name = "ABMMGKJPPH",
                            Unit = "G"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Fatty",
                            Count = "9",
                            Name = "OWURMEVYPS",
                            Unit = "G"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Vegetables",
                            Count = "8",
                            Name = "IPQOYUSYHW",
                            Unit = "Ml"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Fish",
                            Count = "8",
                            Name = "BAFNWRMCYY",
                            Unit = "G"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Fruits",
                            Count = "4",
                            Name = "VZZHHSAQFM",
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Meal",
                            Count = "4",
                            Name = "UGOWWJZXGT",
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Fatty",
                            Count = "4",
                            Name = "DNPOLNPHKF",
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 8,
                            Category = "Sweet",
                            Count = "5",
                            Name = "URGOVVUAPK",
                            Unit = "Ml"
                        },
                        new
                        {
                            Id = 9,
                            Category = "Meal",
                            Count = "7",
                            Name = "XWQWVLCHYD",
                            Unit = "Pcs"
                        },
                        new
                        {
                            Id = 10,
                            Category = "Fatty",
                            Count = "7",
                            Name = "XFGRSAUVKZ",
                            Unit = "G"
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficult")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "UTLRXJXPJAQMWYQCIUTTXZUAVCJVFCTKMSJTSMWCYUWSSFUWUAQUDWIMCMFCEPAHQJYJROURAUMJDVJSEIUVJEHVMXYIXCNECMPVHMTGLFNYFBNNPIXVXJBCMTPPMOGJGNHDRMZFEUUHWSKXLGOJNDUUXLKNSKIIUUSRPUEFHHXYSZJSMWCDONMPCXAFGTIOIUVXDVJBUXKCEIAQVSSCBCJZKMBCGASZCLNIQFYBYYHCFLWRCZKJUCFLUEMOQOHWHBLWJUFVDESAEXVBEDYYTLOPRGFMKIRQMGSDYJOSHMQNTHDNTOUORVMPGJNYJRYTDOMWPKKBRVQVXJPMZPOWXLXFRIZQTYWBZSCRJUZXGHJOROEDPINXTEPKXOUKLAIKVMCVYIEBKRLWQNMDGELCVGWPGUUJGLTATUZGFEJRRMINOWHJPTLDYKUTKAAEQHVABVDRSOQZAJWNNODZJMNHWVDVZIUQUUINEMIYUYOXIEJSLOAJHJVM",
                            Difficult = 1,
                            Name = "DUXPGNUCEI"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ZTUOSPODUQQLSKLTSBOOPKJIHHTKDXGEDPYTYDATVQZPIVFRRCHVGRCPUGAVWJWRFGDRQXBSCNFYDLEGKLNFTMYDGRDUVFXMYJNPZVTNKXMEIXIHFPXUEOGGKWNASBIZCEWVYDJNOSOPJSSCQTZCRDCPZLVTSYNDEHPENILXJZIGRSYYFFOCCRFRQELQFZYCEQTUPNDHSPCGRLCLEZUGUXTCCVEUIFVXUSVQMEFMZFUIRRMUKZOQWPQDYKCEOISAYIHZBJTMFMRYTIQVLCCIZRYDIOLPEQOBWVRIWNXWQRAFSWOGIZFZIBZFRORNNFFBWAGFRDBCSPUWBUJRNZDFTAUNLVIUDPHIEZMJIWOCZUPRMULQYFAVNLEWXUKVFPENCXIEOWDRQUAGOTJWZLSYKEJHYIKIZGHJZWSECCBRWROCTXAZKJYTTQPBMVOJDPOQONQWAVVQKXWGOCFPQTHEYCWSYMSQMSHCORBTWKETPNQTJFTAPPWA",
                            Difficult = 3,
                            Name = "PITIZDBKQF"
                        },
                        new
                        {
                            Id = 3,
                            Description = "JLLYVAHNFARUWIOBMDNMONAEYEEZWUPOQNXDENOMZPIXKXQALPOWTVAKKJYKYEWHZLKRJVCSAHLVWCFLVWDSZAPCIJJNDNDRTDZPEKFFQKLZYOPNBKDAKPSLAWHEXDSQRPMMBDOBUYSNIRXBLGSYVJURLHWVDTRSVGUOXLCHWHPFANHROSKSHCOYVOGVRSJQYARQHMQDBARZMIATLTRRKWOHXMXGMHDUDSIPRFLQOBTISPKCTXHYLZBQOFSLRDLELJXUVBDDQBONBWYEUCVODIJGAHNVFOEWCAMEASOYCAQVCOVWAKLQSUMSVBBDLHRIPWXHWSHKNEQPIOQRJVJWCEKITIWUKPIMXKIQRNCNZMDKRZHYHVYCEQLRWKXRZGQDFZGZJUZKSCYXEFABVCMSKMDQPMUOTIBTHHQSOWUPIHSUGVGZDDSORDMLUBUXAKXYEAKKWDVAOPCYCHAXVYZVNDVAHCZDFILBKWBPMDYKYEDUGXYDFCZL",
                            Difficult = 3,
                            Name = "UOSOXWEESM"
                        },
                        new
                        {
                            Id = 4,
                            Description = "SUJPQUIHNHWUJRTXSONLKZLIEVFFKXOZPTUAMSVHWHUKBXEVDOCXPICNZPJNFRRZYWAKZAWYCANPFOYBZNCEXULEVNVFXISYDZGHTMTFQXHVRRDDWKZQNOIYFJTRZHUEXUALLLPPIKBWMQDHCSUKXRBIRRWJHHIMXHBQTAFMJOYNVNMZGXSHYNALDXIJXYHSUNZOGKONCWAHJVWFDSVPAWQRJZYNUHZYYCXTFURZNSUDTJCMFAQICQWERAEOAVXRLXDADGRRDKMSLGFCJGIKAFIAIXZSINRMHUJZASXZZUQRQCLAHCLPSGMYMCZQCTBKXJUTLPWTENEXEYQHIOCMWSUPCLYXDQJRDDPPDZIWDBBQAJYXSTGTKMSFGKKLIWTYTUFJUTFVGUEIZANAHEMOSBHZZJKJUZMTLCHSOMXJRTZMUSOSAUHLZMTPLGMYMPWIXIQDTEPMHXIEVXBFRDTDUGZRZFZXFEHJMOIGSBVKGNZXRTHYTOGD",
                            Difficult = 2,
                            Name = "AOUZPEOHAN"
                        },
                        new
                        {
                            Id = 5,
                            Description = "ADMQWQMYITUMMFWAJMNBRMNXVISWGMVRWQWRFAYXACFUASOKBUVAQNKACMNYRSRPBAFVGAPWCMKKUHUFCHGPGVXAVJMVICRETZHHQRGSZIYXWQRAAZCJATHGXGSOEGUTGCSGDLNMWKOZIWVEGGXAJPWQMMHXUQXUHSDHTIBSBMFZVUNTULQIMNTCTNZLIKOWJBEKHMAPOWXMACPXXIWNIOSXKANCRVMCHLVXYGWLOJKTJBBWHJETFDUDEPPLGIBUZQXVWTKNSZXYDOHNFRAQCFNOZWHMZSRGWFQHSLXGNRKLTFZPWYOJMDWPJTSSCRTKVNXDSWXSRZJLQRQWTFVLUPBHUOAYLDNBHWOWMACVJQULMFJMOAMIGBROVRSSHTKNSHUGDPKJMLXXGZUNYVLKMWQCVUDLTQCLOWNMZNBLFHRAQOGTFFNMBKMUAIHXKQHJXYYIKTLFCNHJZOJFCGEQZNHMDVFIBSVCIJACNJPWSOHAKVWMWFNQ",
                            Difficult = 3,
                            Name = "ERNEUWIXTI"
                        },
                        new
                        {
                            Id = 6,
                            Description = "MPRSKREGGHEALUNOZOEALTBGEBPJHQJOFKXSDFMPPFUQUFPLPMAJRUYMNHLRATCNQFZYYLBQKOTTPTAGBMJCMDWZFEMQXKCQXTGSNFKBNUJNWEVIAGTRZEZHMQEOKOHEZQKGZQQFNCBSGXMWRFEYQZKYXDJHVZJBSGVVLSEMQMFDWTFWKTQUHUVSOTYARQYPHDGRLADCAYJCCLNEHGSEUTJSPVWCTYPOBISITFZAASCKAGWFWVFMBZDTBETXWIHXQPATGBGOQUHOZYXRPLJBIORZDFJUNRZWIBQJDKIDLEQSWKXSLGYJYCGMDCIFZBXCHRNGIDHISRCZQBZZWHWPRKBJWPKLGOCFZJMJQQMXYUZJEUSBTWBYWLBZLNINKJWFBVBDZSAMKVDAZUGGOHWUZBARTFITPGEZVMIJIZYVJDDXTRDMBMPHNIWRXXMEVNXKYGBPHLMYIMKMCZCEPFAWCLRIHZIHZLLDUKVKMMUBGTBZYIEBIRRJ",
                            Difficult = 2,
                            Name = "CAKSFXQWGF"
                        },
                        new
                        {
                            Id = 7,
                            Description = "GNKXWRVRNMXZSUBVAUAFKDSMYJFPHQYIBFIESZVUVMQBHDJOVZISKLBAZNZKLYDPXYPDSQFMVQMPEQHSBAJZOUKRIBNMLQNLDXZUXMTAFDZTCHFPGAGOIMVBJQVFEHLJFXONTQXBDZHEBWJLWFLVCRLFWIMNKXERCWXNWHIITMEUSUPHIVRSOZUDDAYCAOLUTSOVZXLUPNWHPXQPESWXRXUSEHCKLKOCAQDOYJNOXTYCPYITYXAVBFHOTLHINWBWEFHQVDCVMGBVQIQUOMKYMLJOVQIUFBMONJZRIMXAASNTSRPQXVYJUQEZWIIODIRDPKJKHKAZTRAJLZTJMMPFSRCGVSLZGMEDUFZUTRVGLTSUCUHONBINXRWYPDQWUSWOTRZYZMMBCKDXAMUIBXOBJRQIDDTNITSBTUBCHHIZSEDIFKKJQGPVEKRGGRZVZIGMPWTKFVKFBQITNKPELWRVUYVTXQSRHBLCGVYVGAVNYOAULJHYOEJD",
                            Difficult = 2,
                            Name = "XIUEIAIOJV"
                        },
                        new
                        {
                            Id = 8,
                            Description = "GZRJQCYRCUAZPNPNJWBGDGGIJWARDGHCGELNGWNGWXRUCORUAEBQZXRMGRRHXRMIEXSYJZVSJRNFBPZEEBFPXDAIHBQOBTMVEWILTAAVUWZZCLOLXTYLIVPXFNCVIUAZLAIGXUCIJJQLOAQIWIIHVZYTXJFUHDEXTSLWFPGQHDIRYHNILMJIJNHAUPFIVASQJWJJWHWEXUBQCMDHDVLTCEBSNAIFHTBFVUUTFARSFMZEMWHNFVTTAOCBPPFXFMFBSZDCICMMHUFTKDQPAZXJYBPPHCDPLOJEERNXNLJMDRKWKFONORMXSNXDCZTGOAGSLKUKYKCOQAJZJHQQFFSVQVPJFUOZNRVQXZCISSJICQIGGYQJDKVEEFNGISOXNRHYOWBVNNXUTXUTNBMHAZZOFDNZXJKROGQYDRBSKAAZBWXENAZSWIZFJIPUBMJASCLFISSQQQBXAVLHQQTWPWVJWGWHWBHNOBBTDPAXVLJINRPSOOYDOPRT",
                            Difficult = 2,
                            Name = "LVJRBAJPKD"
                        },
                        new
                        {
                            Id = 9,
                            Description = "JDKQYKJLOFHLJICDITPOAXNRHTKDZWAXHKSXFSCRFKXFAXZNSQJHCYIJHRHOQLMOLMDGAOCATOQPGJNDSQWAFVATUDWYFJSTBFZDBDPSQUKDDENBPJYUUBQCRIIJWIAZZDUBRFZAKVFZYLNMPLBZZMKUBQEUEUAJMLYTLIZQDGEBWPFYJQPIWESQHNWMAAZMUSXIEMCWAINRMITJJMTBKGQRDEOJGOTJJRGNFPGJIZDTJCFAOHRKCBVHDKTHKDMMHGITXEPZKYXTKIZOHDCGYQUPNHAZFBXJDAMFJSIPQWRGHQHXMKQYZUTEQHWTOJJDMKWJJWEDBUCWPRCFQGEMAVKFWHNGOPWBFQOLLWGYRWQSGODLJWVSWFLZWMGFAYSNSYWWCHFVYRAHMQIQAHOFVRTGREOLHQEJDDVYZQRWWXFUZCITZARYVSVLIFGZZEICKESVBLAXLOMLXLQCBJHVUBKXSWYGTZQNCKDZYZHWEFBOLAVSSOWQ",
                            Difficult = 1,
                            Name = "TNZLUUFNSR"
                        },
                        new
                        {
                            Id = 10,
                            Description = "MVKCQZJBGBSBEIKEROWVLSVKTTHFQGHWESTZNEXSKNFALGXHFWICSBSTIWGMGMHETROGDFQWUCQJMNYMODXRQNBOGPHUTLEWGWQFUVXTSBOUTYQGBEQKLGWZPZISQBZRQOXMCSBLAGBHCBBIHRFQSOYFTQBTPFMOKJUZOAQAVIMHWOMIPHPBJBXRKTZOXMZBHPHORBQWOBWVRLATMJCYCMGXVLRIUJCPJTCCPSOXFMUJYVOLMZZFYYIRMMTJKYQMSHZKYITYUMGTUGNGAEEKRADCPNGYULESORPPTWKRQGCNRBALDHNITRVSTNAXLAOJJEZIGYRYOJRKNMTLTIKWASWXGBVZYTGJNTHXFFXNEUREWZMIILEMQZRFHSTCECJCZNTIQKQDNFOJVJQVADFMDSYNWXGOGXCUSEPLADXWEKPTNHBUPEOSESLPFMOWRZXFQFFIKYQVCAZVMUZGWNAWYLGEWHZHGMWMIGCCFYKDLYHDMOYBVRJM",
                            Difficult = 3,
                            Name = "VGGKKTEWCL"
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "IRTAMGZ@gmail.com"
                        },
                        new
                        {
                            Id = 6,
                            Email = "CCUPARY@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Email = "VXMEPTY@gmail.com"
                        },
                        new
                        {
                            Id = 7,
                            Email = "QZCOETK@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            Email = "PRIFTBD@gmail.com"
                        },
                        new
                        {
                            Id = 8,
                            Email = "VPNFIJY@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            Email = "CWWEISB@gmail.com"
                        },
                        new
                        {
                            Id = 9,
                            Email = "OAPVFPT@gmail.com"
                        },
                        new
                        {
                            Id = 5,
                            Email = "BIPHVKT@gmail.com"
                        },
                        new
                        {
                            Id = 10,
                            Email = "NJYADQL@gmail.com"
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.HasOne("FoodSimpleWebApi.Models.RecipeDto", null)
                        .WithMany("Products")
                        .HasForeignKey("RecipeDtoId");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
