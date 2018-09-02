<map version="1.0.1">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1523551435019" ID="ID_575210695" MODIFIED="1530319984484" TEXT="The Development Timeline">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315659502" ID="ID_329295681" MODIFIED="1534738900015" POSITION="right" TEXT="Stage 1 (Mechanics)">
<richcontent TYPE="NOTE"><html>
  <head>
    
  </head>
  <body>
    <p>
      <font size="3">This outlines all the mechanics inside the game, these are just the base mechanics that will make the game work... </font>
    </p>
    <p class="MsoNormal">
      During this stage there will be ABSOLUTELY NO MODELLING. Everything will be done through cubes and blank terrain objects to test all the elements, maybe some cliffs may be added but apart from that nothing more.<o p="#DEFAULT"></o>
    </p>
    <p class="MsoNormal">
      <o p="#DEFAULT">
      &#160;</o>
    </p>
    <p class="MsoNormal">
      By the end of this stage all the scripts needed for the rest of the game should be ready so everything can be easily implemented with the graphics. But more graphically oriented scripts will be added later including shaders and scattering.<o p="#DEFAULT"></o>
    </p>
  </body>
</html></richcontent>
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315712566" FOLDED="true" ID="ID_1923352396" MODIFIED="1534739018384" TEXT="Sprint 1">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315716350" FOLDED="true" ID="ID_1724433076" MODIFIED="1534739016659" TEXT="Player Mechanics">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315737670" FOLDED="true" ID="ID_370109284" MODIFIED="1534739016659" TEXT="Over the shoulder navigation">
<icon BUILTIN="full-1"/>
<node CREATED="1530326692449" ID="ID_1962233923" MODIFIED="1530326695527" TEXT="From Old Script"/>
</node>
<node CREATED="1530315742318" ID="ID_1841336415" MODIFIED="1530326648898" TEXT="Smooth camera movement">
<icon BUILTIN="button_ok"/>
</node>
<node CREATED="1530315745605" ID="ID_1114466679" MODIFIED="1530319927916" TEXT="Dynamic player control">
<icon BUILTIN="button_ok"/>
</node>
</node>
<node CREATED="1530315752094" FOLDED="true" ID="ID_1092631139" MODIFIED="1534739016659" TEXT="Locomotion (Non-animation)">
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="messagebox_warning"/>
<node CREATED="1530315759390" ID="ID_77866767" MODIFIED="1530319651245" TEXT="Parkour"/>
<node CREATED="1530315763069" FOLDED="true" ID="ID_1412560854" MODIFIED="1534739016659" TEXT="Ledge Climbing">
<icon BUILTIN="full-2"/>
<node CREATED="1530326706336" ID="ID_114992772" MODIFIED="1530326708242" TEXT="Dynamic"/>
</node>
<node CREATED="1530315765637" ID="ID_1203639216" MODIFIED="1530319651245" TEXT="Gliding"/>
<node CREATED="1530315768558" ID="ID_62779767" MODIFIED="1530319651245" TEXT="Object Hooking"/>
</node>
<node CREATED="1530315789470" ID="ID_1000756651" MODIFIED="1530319933532" TEXT="Optimised Player Movement/Environmental Traversal">
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="button_ok"/>
</node>
<node CREATED="1530315877621" ID="ID_450659534" MODIFIED="1530319651245" TEXT="Parse into custom class &amp; setup static scripts that are accesible throughout the game">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318630027" FOLDED="true" HGAP="29" ID="ID_615341222" MODIFIED="1534739016659" TEXT="Expected Results" VSHIFT="44">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318638313" ID="ID_434741280" MODIFIED="1530319651245" TEXT="&#xf0a7;Player Controller w/ all features needed (responsive and powerful movement w/ procedural forces)&#xa;&#xf0a7;Camera Dynamic Movement (Camera collision, movement) account for bow movement&#xa;&#xf0a7;Over the arm arrow shooting (Arrow curve and bend when you shoot, wind accounting, different bow powers). Smooth and aiming.&#xa;&#xf0a7;Optimising the code&#xa;"/>
</node>
<node CREATED="1532215701116" FOLDED="true" ID="ID_1008434761" MODIFIED="1534739016659" TEXT="Player Polish Stage">
<node CREATED="1532215705068" ID="ID_1282976975" MODIFIED="1532215709584" TEXT="Fixing all going through wall bugs"/>
<node CREATED="1532215711947" FOLDED="true" ID="ID_113053656" MODIFIED="1534739016659" TEXT="Fixing Jump">
<node CREATED="1532215714452" ID="ID_353306645" MODIFIED="1532215718704" TEXT="Hold increases dist"/>
<node CREATED="1532215719243" ID="ID_1197690917" MODIFIED="1532215723240" TEXT="Lasts only 0.9 seconds"/>
<node CREATED="1532215723876" ID="ID_945438162" MODIFIED="1532215729737" TEXT="Make sure movement in air is limited "/>
</node>
</node>
<node CREATED="1534239528937" FOLDED="true" ID="ID_1099129885" MODIFIED="1534739016659" TEXT="Actionables">
<node CREATED="1534239530725" ID="ID_484916419" MODIFIED="1534239532694" TEXT="Picking up items"/>
<node CREATED="1534239533370" ID="ID_322800016" MODIFIED="1534239534726" TEXT="Moving things"/>
<node CREATED="1534239535610" FOLDED="true" ID="ID_1019580803" MODIFIED="1534739016659" TEXT="Interactions basics">
<node CREATED="1534239542178" ID="ID_1363818886" MODIFIED="1534239547281" TEXT="Write an interface for this"/>
</node>
</node>
</node>
<node CREATED="1534739023944" FOLDED="true" ID="ID_1257955835" MODIFIED="1534832750077" TEXT="Sprint 1 Polish">
<node CREATED="1534739030398" ID="ID_530157146" MODIFIED="1534739032464" TEXT="Ledge Climber">
<node CREATED="1534739047816" ID="ID_1624139174" MODIFIED="1534739055441" TEXT="Clear up the ledge script"/>
<node CREATED="1534739056294" ID="ID_200093448" MODIFIED="1534739060949" TEXT="Manage drop connections"/>
<node CREATED="1534739061533" ID="ID_831020865" MODIFIED="1534739068825" TEXT="Gett attatch points working for the jump"/>
</node>
<node CREATED="1534739069418" ID="ID_85771112" MODIFIED="1534739072316" TEXT="Player Controller">
<node CREATED="1534739072545" ID="ID_1794423648" MODIFIED="1534739078156" TEXT="Using AddForce for the rigidbody"/>
<node CREATED="1534739079000" ID="ID_1623551575" MODIFIED="1534739086155" TEXT="Safety Checks based on LD Game"/>
</node>
</node>
<node CREATED="1530315825198" ID="ID_1108077419" MODIFIED="1535332281484" TEXT="Sprint 2">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315829845" ID="ID_302205264" MODIFIED="1534821921731" TEXT="NPC Mechanics">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315832518" ID="ID_1071862328" MODIFIED="1530319651245" TEXT="Behaviour Trees">
<node CREATED="1530318493100" ID="ID_1302762996" MODIFIED="1530319651245" TEXT="Base NPC Mechanics">
<node CREATED="1530318499802" HGAP="21" ID="ID_1777207833" MODIFIED="1530319651245" TEXT="&#xf0a7;Behaviour Editor&#xa;&#xf0a7;Custom Regional Path finding&#xa;&#xf0a7;Friend NPC&#xa;&#xf0a7;Build upon dialogue system&#xa;&#xf0a7;Designing the AI States and beginning proceduralised states&#xa;&#xf0a7;Writing the complex + dynamic combat system.&#xa;&#xf0a7;This entails tactical fighting, so I want smokes, long distance sniping, flashes, emps. I want the combat system to be the most fleshed out part of the game with extremely responsive and smart NPC&#x2019;s as well.&#xa;&#xa;&#xf0a7;&#x9;Realistic NPC (Friend)&#xa;&#xf0a7;&#x9;Writing the communication system what each hand signal means and how  your friend will react to each one.&#xa;" VSHIFT="16"/>
</node>
</node>
<node CREATED="1530315837190" ID="ID_415567656" MODIFIED="1530319651245" TEXT="Pathfinding Algorithms">
<node CREATED="1530315842901" ID="ID_478939754" MODIFIED="1530319651245" TEXT="Implemented w/ Job System"/>
<node CREATED="1530315848045" ID="ID_115945104" MODIFIED="1530319651245" TEXT="Heap Trees"/>
<node CREATED="1534821931916" ID="ID_527035465" MODIFIED="1534821938833" TEXT="Quad tree structure">
<node CREATED="1535334009947" ID="ID_970494183" MODIFIED="1535334016221" TEXT="Regional Pathfinding"/>
</node>
<node CREATED="1535332288366" ID="ID_125794188" MODIFIED="1535332293595" TEXT="Allowance of ledge climbing"/>
<node CREATED="1535333994132" ID="ID_1193699004" MODIFIED="1535334000391" TEXT="Optimisation To Extreme Levels"/>
<node CREATED="1535334001267" ID="ID_1696158136" MODIFIED="1535334004574" TEXT="Jump Point Search *"/>
<node CREATED="1535334022138" ID="ID_804155726" MODIFIED="1535334026459" TEXT="Pathfinding Editor Script">
<node CREATED="1535334026848" ID="ID_1153431448" MODIFIED="1535334049396" TEXT="Allows to create paths using quads of a surface..."/>
</node>
</node>
<node CREATED="1530315853630" ID="ID_411978181" MODIFIED="1530319651245" TEXT="Sensory Data &amp; Environment Response">
<node CREATED="1535333976727" ID="ID_812907116" MODIFIED="1535333988447" TEXT="Vision">
<icon BUILTIN="button_ok"/>
</node>
<node CREATED="1535333978823" ID="ID_1464447084" MODIFIED="1535333980002" TEXT="Hearing"/>
<node CREATED="1535333980584" ID="ID_1143331232" MODIFIED="1535333980584" TEXT=""/>
</node>
<node CREATED="1530315868701" ID="ID_1145589943" MODIFIED="1530319651245" TEXT="Smart Following Behaviour">
<node CREATED="1535332294870" ID="ID_1417560024" MODIFIED="1535332297181" TEXT="Ledge Climbing"/>
<node CREATED="1535332299673" ID="ID_978031956" MODIFIED="1535332306467" TEXT="Variations of paths"/>
</node>
<node CREATED="1530315904903" ID="ID_392964188" MODIFIED="1530319651245" TEXT="Creating the Editor for the NPC&apos;s"/>
<node CREATED="1530315913877" ID="ID_58403230" MODIFIED="1530319651245" TEXT="NPC Profiles / Behaviour Trees that link w/ Pathfinding"/>
<node CREATED="1530319329568" ID="ID_1553650929" MODIFIED="1530319651245" TEXT="Horde Systems">
<node CREATED="1530319332353" ID="ID_860427735" MODIFIED="1530319651245" TEXT="Perlin Noise for Horde Movement"/>
<node CREATED="1530319337025" ID="ID_1491116172" MODIFIED="1530319651245" TEXT="Pathfinding Ray Based"/>
<node CREATED="1530319341537" ID="ID_550327500" MODIFIED="1530319651245" TEXT="Relative to Player"/>
</node>
<node CREATED="1530329581899" ID="ID_1452874617" MODIFIED="1530329589070" TEXT="NPC&#x2019;s pathfinding w/ animation &amp; pre-defined actor to be destroyed"/>
<node CREATED="1535501572350" ID="ID_259145014" MODIFIED="1535501575696" TEXT="Tactical systems"/>
<node CREATED="1535501576174" ID="ID_1077569844" MODIFIED="1535501579058" TEXT="NPC&apos;s working together"/>
</node>
</node>
<node CREATED="1530315936077" ID="ID_1911455245" MODIFIED="1534832751885" TEXT="Sprint 3">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315939181" FOLDED="true" ID="ID_1467348356" MODIFIED="1534738929703" TEXT="Stealth Systems">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315942941" ID="ID_1510528936" MODIFIED="1530319651244" TEXT="Distractions"/>
<node CREATED="1530315946741" ID="ID_319725120" MODIFIED="1530319651244" TEXT="Looting &amp; Sneaking Around"/>
<node CREATED="1530315952934" ID="ID_811210764" MODIFIED="1530319651244" TEXT="Enemy Identification">
<node CREATED="1530315959262" ID="ID_1418247245" MODIFIED="1530319651244" TEXT="Spotting enemy &amp; Scanning"/>
</node>
<node CREATED="1530318155299" ID="ID_787644426" MODIFIED="1530319651244" TEXT="Brainstorm/Collect Ideas"/>
</node>
</node>
<node CREATED="1530315989606" FOLDED="true" ID="ID_1860429508" MODIFIED="1534832755200" TEXT="Sprint 4 ">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315992093" FOLDED="true" ID="ID_778734485" MODIFIED="1534738927224" TEXT="Combat System">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530315995365" ID="ID_532951232" MODIFIED="1530319651244" TEXT="Mechanical Weapons">
<node CREATED="1530316005821" ID="ID_980022531" MODIFIED="1530319651244" TEXT="Recoil"/>
<node CREATED="1530316008333" ID="ID_1385580961" MODIFIED="1530319651244" TEXT="Ammo"/>
<node CREATED="1530316009725" ID="ID_1618387287" MODIFIED="1530319651244" TEXT="Management/Inventory (mass)"/>
</node>
<node CREATED="1530316018317" ID="ID_1880837982" MODIFIED="1530319651244" TEXT="One on One combat">
<node CREATED="1530316024445" ID="ID_700554515" MODIFIED="1530319651244" TEXT="Overgrowth Style Procedural Combat"/>
<node CREATED="1530316040245" ID="ID_161509776" MODIFIED="1530319651244" TEXT="Brainstorm ideas on how this will work"/>
</node>
</node>
<node CREATED="1530316049726" FOLDED="true" ID="ID_347940912" MODIFIED="1534738925302" TEXT="Player / Friend NPC Combat">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530316058005" ID="ID_443418647" MODIFIED="1530319651244" TEXT="P &amp; F Health / Stamina Systems"/>
</node>
</node>
<node CREATED="1530316144419" FOLDED="true" ID="ID_144611184" MODIFIED="1532401477701" TEXT="Sprint 5 (Editor Mechanics)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530316149238" ID="ID_329933992" MODIFIED="1530319651244" TEXT="Audio Machine (for audio blending)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318803826" ID="ID_1168508693" MODIFIED="1530319651244" TEXT="-Watch the talk on how game systems actual blend noises together&#xa;-Make sure sounds do not feel choppy and they flow to the next sounds.&#xa;-Blending of sounds in the background, noises that are more important are given more power.&#xa;-Sounds are disabled and enabled based on situations.&#xa;-Use the rule where if there are more than x of the same sounds do not over clutter. &#xa;-Make sure the sounds system is implemented into the behaviour editor.&#xa;-Create a script to easily be able to call on an audio file which is stored in a dictionary.&#xa;-Audio editing and blending.&#xa;&#xa;Adding music: (This is your best for creating high quality music : http://www.soundsonline.com/composercloud)&#xa;YOU MUST 14/month for high quality string, choirs everything you need! &#xa;"/>
</node>
<node CREATED="1530316157086" ID="ID_1499631532" MODIFIED="1530319651244" TEXT="Custom Render Pipeline">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530316164717" ID="ID_149138641" MODIFIED="1530319651244" TEXT="Asset Management"/>
<node CREATED="1530316171295" ID="ID_871072463" MODIFIED="1530319651244" TEXT="Auto LOD Generation"/>
<node CREATED="1530316177252" ID="ID_1161584320" MODIFIED="1530319651244" TEXT="Auto Layer/Tag assigning"/>
</node>
<node CREATED="1530317613571" ID="ID_1945373787" MODIFIED="1530319651244" TEXT="Light Manager">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317619043" ID="ID_1982578534" MODIFIED="1530319651244" TEXT="Asset Manager">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317623052" ID="ID_1303051676" MODIFIED="1530319651244" TEXT="NPC Behaviour + A* Editor">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530317793667" FOLDED="true" ID="ID_1359176365" MODIFIED="1534738918387" TEXT="Story Integration Sprint 8">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317242268" ID="ID_1490398486" MODIFIED="1530319651244" TEXT="Dialogue System">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317247628" ID="ID_632232664" MODIFIED="1530319651244" TEXT="Side by side UI for Dialogue"/>
<node CREATED="1530317805363" ID="ID_1971640091" MODIFIED="1530319651244" TEXT="Multiple Path Dialogue"/>
<node CREATED="1530317814987" ID="ID_736894424" MODIFIED="1530319651244" TEXT="Cinematics Dialogue"/>
</node>
<node CREATED="1530317820947" ID="ID_190136262" MODIFIED="1530319651244" TEXT="Story Event System">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317824842" ID="ID_760251946" MODIFIED="1530319651244" TEXT="Cinematic Trigger System"/>
</node>
<node CREATED="1530318139388" ID="ID_81951647" MODIFIED="1530319651244" TEXT="Spawning &amp; Event Systems">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318543712" ID="ID_1586043557" MODIFIED="1530319651244" TEXT="Player / World Relations">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318547290" ID="ID_1005506406" MODIFIED="1530320148164" TEXT="&#xf0a7;Guide Systems (This is the system that helps you at the start and throughout the game when you are stuck)&#xa;&#xf0a7;Player and world Interaction (Refer to sheet)&#xa;&#xf0a7;Realism and Co-Existing World&#xa;&#xf0a7;Realistic sense of time (Time manager and day management + recording)&#xa;"/>
</node>
</node>
<node CREATED="1530317179108" FOLDED="true" ID="ID_61835279" MODIFIED="1534832761247" TEXT="Sprint 6">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317197579" ID="ID_1281843655" MODIFIED="1530319651244" TEXT="Inventory System">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317203388" ID="ID_801248679" MODIFIED="1530319651244" TEXT="Trading System">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317209555" ID="ID_406072287" MODIFIED="1530319651244" TEXT="Build NPC and Player Interaction"/>
</node>
<node CREATED="1530317220627" ID="ID_1396422853" MODIFIED="1530319651244" TEXT="Communication Menu">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317226467" ID="ID_1515456509" MODIFIED="1530319651244" TEXT="Actions combined with Dialogue"/>
</node>
<node CREATED="1530317918203" ID="ID_1016740561" MODIFIED="1530319651244" TEXT="Map UI (Properly Created w/ Icons)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317942203" ID="ID_417996083" MODIFIED="1530319651244" TEXT="Laid out on plane"/>
</node>
<node CREATED="1530318415010" ID="ID_993166061" MODIFIED="1530319651244" TEXT="Survival ">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318417251" ID="ID_38131415" MODIFIED="1530319651244" TEXT="&#xf0a7;Health and Damage system &#x2013; Regeneration period//Injury System as well//Affecting attrs like speed etc.. &#xa;&#xf0a7;Map System&#xa;"/>
</node>
</node>
<node CREATED="1530317304140" ID="ID_690639792" MODIFIED="1534832763559" TEXT="Sprint 7">
<richcontent TYPE="NOTE"><html>
  <head>
    
  </head>
  <body>
    <p>
      This is not the actual world design of this open world, just the systems required to make such a big world work...
    </p>
  </body>
</html></richcontent>
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="yes"/>
<node CREATED="1530317314836" FOLDED="true" ID="ID_348102100" MODIFIED="1535332276363" TEXT="Open World Building">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317358100" ID="ID_483274400" MODIFIED="1530319651244" TEXT="Custom World Streaming">
<node CREATED="1530317364252" ID="ID_1638932051" MODIFIED="1530319651244" TEXT="Using the Scene Manager "/>
<node CREATED="1530317369387" ID="ID_585373021" MODIFIED="1530319651244" TEXT="Custom LOD techniques"/>
</node>
<node CREATED="1530317376611" ID="ID_1952532801" MODIFIED="1530319651244" TEXT="Foilage Optimisation">
<node CREATED="1530317386412" ID="ID_1510033143" MODIFIED="1530319651244" TEXT="GPU Instancing"/>
<node CREATED="1530317839588" ID="ID_1440369582" MODIFIED="1530319651244" TEXT="For each scene build a txt file of pre-positioned foilage ">
<node CREATED="1530317865163" ID="ID_1704625296" MODIFIED="1530319651244" TEXT="Load them in dynamically by reading"/>
</node>
</node>
<node CREATED="1530317383156" ID="ID_1673844556" MODIFIED="1530319651244" TEXT="Job System">
<node CREATED="1530317389707" ID="ID_1264852894" MODIFIED="1530319651244" TEXT="Dynamically Loading Scenes into game"/>
</node>
<node CREATED="1530317407579" ID="ID_1015917738" MODIFIED="1530319651244" TEXT="World Builder">
<node CREATED="1530317410675" ID="ID_1885917510" MODIFIED="1530319651244" TEXT="Editor Window that manages ^^^^"/>
<node CREATED="1530317417884" ID="ID_1585778655" MODIFIED="1530319651244" TEXT="Works in conjunction with CRP ">
<node CREATED="1530317425964" ID="ID_610212248" MODIFIED="1530319651244" TEXT="CRP tells the World Builder how to contruct the world"/>
</node>
<node CREATED="1530317440051" ID="ID_275291333" MODIFIED="1530319651244" TEXT="OC "/>
</node>
<node CREATED="1530317462099" ID="ID_1610474555" MODIFIED="1530319651244" TEXT="This needs to be further broken down when the time comes to do this Sprint"/>
</node>
</node>
<node CREATED="1530318722163" FOLDED="true" ID="ID_986448887" MODIFIED="1534738968732" TEXT="Sprint 9 (SL)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318730874" ID="ID_1454936657" MODIFIED="1530319651244" TEXT="&#xf0a7;Saving and loading user data&#xa;&#xf0a7;Writing the camera effects&#xa;&#xf0a7;Writing UI Effects&#xa;&#xf0a7;Release assets that you made on the asset store&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
</node>
<node CREATED="1530315665318" ID="ID_183294155" MODIFIED="1533255988529" POSITION="left" TEXT="Stage 2 (Game Building)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530316081437" ID="ID_238517133" MODIFIED="1530319831049" TEXT="Model Asset Development">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530316091701" ID="ID_761772980" MODIFIED="1530319832101" TEXT="Players">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317486428" FOLDED="true" ID="ID_12329289" MODIFIED="1530319842221" TEXT="Player Modelling">
<node CREATED="1530319834736" ID="ID_1250291200" MODIFIED="1530319839460" TEXT="i.Various tools and weapons + an extensive look into the suit and how to make it more dynamic looking&#xa;ii.Loot system &#x2013; taking clothes, inventory etc..&#xa;"/>
</node>
<node CREATED="1530317533892" FOLDED="true" ID="ID_734140682" MODIFIED="1530319833765" TEXT="Player Rigging">
<node CREATED="1530319511961" ID="ID_1398699828" MODIFIED="1530319651244" TEXT="-Animating the living things based on recorded footage of me.&#x9;&#xa;-Keep in mind the principles of animations when animating, anticipation is important + mass consideration using sliders?&#xa;">
<arrowlink DESTINATION="ID_1398699828" ENDARROW="Default" ENDINCLINATION="0;0;" ID="Arrow_ID_1759100404" STARTARROW="None" STARTINCLINATION="0;0;"/>
<linktarget COLOR="#b0b0b0" DESTINATION="ID_1398699828" ENDARROW="Default" ENDINCLINATION="0;0;" ID="Arrow_ID_1759100404" SOURCE="ID_1398699828" STARTARROW="None" STARTINCLINATION="0;0;"/>
</node>
<node CREATED="1530319532705" ID="ID_110138058" MODIFIED="1530319651244" TEXT="Animations">
<node CREATED="1530319534376" ID="ID_408290684" MODIFIED="1530319651244" TEXT="Blend Animations for Everything"/>
<node CREATED="1530319544065" ID="ID_4910309" MODIFIED="1530319651244" TEXT="Refer back to old notes"/>
</node>
</node>
<node CREATED="1530317536796" ID="ID_1050818275" MODIFIED="1530319651244" TEXT="Player UV Maps"/>
</node>
<node CREATED="1530316094124" FOLDED="true" ID="ID_387720458" MODIFIED="1530319793412" TEXT="NPCS">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317486428" ID="ID_1253706969" MODIFIED="1530319651244" TEXT="Modelling"/>
<node CREATED="1530317533892" ID="ID_605283509" MODIFIED="1530319651244" TEXT="Rigging"/>
<node CREATED="1530317536796" ID="ID_731193851" MODIFIED="1530319651244" TEXT="UV Mapping"/>
<node CREATED="1530317683435" ID="ID_386444507" MODIFIED="1530319651244" TEXT="Animals"/>
</node>
<node CREATED="1530316095822" FOLDED="true" ID="ID_1298629605" MODIFIED="1530319795228" TEXT="Level/Environment">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317555611" ID="ID_204773369" MODIFIED="1530319651244" TEXT="LOD&apos;s for everything"/>
<node CREATED="1530317564460" ID="ID_1446592639" MODIFIED="1530319651244" TEXT="Use Blender&apos;s in-build decimate modifier for LOD"/>
</node>
<node CREATED="1530316116389" ID="ID_1224568609" MODIFIED="1530319651244" TEXT="Drops/Objects">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317530571" ID="ID_1420910548" MODIFIED="1530319651244" TEXT="Enemy Models">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530316105389" FOLDED="true" ID="ID_787413037" MODIFIED="1530319711804" TEXT="Audio Asset Development">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317589628" ID="ID_1420067079" MODIFIED="1530319651244" TEXT="Creating the background music">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318842737" ID="ID_1434159314" MODIFIED="1530319651244" TEXT="-Buy FL Studio ($99)&#xa;-Write the theme of the music&#xa;-Learn some music theory (chords)&#xa;-Learning and analysing orchestral music&#xa;-Asking your English teacher about music and a crash course&#xa;-Getting the plugins you need (PB)&#xa;-Then you just have to compose the music and keep trying&#xa;-Write down the different moods and setup songs for each one.&#xa;-Bring it into unity and setup event systems for music and make sure it blends in and out smoothly.&#xa;-Starting screen music from beautiful and calm to deathly and dangerous. &#x2013; Death -&gt; https://www.youtube.com/watch?v=P-48TIWBQyg&#xa;-Menu screen music&#xa;-Credits music (Make it catchy and learn from the legend himself (HANS ZIMMER)&#xa;-Crowd sounds and horde movement make sure the noise isn&#x2019;t over powering.&#xa;-Simple sounds like you brushing against the bushes in times of stealth, everything is important&#x2026;&#xa;"/>
</node>
<node CREATED="1530317595956" ID="ID_1363638874" MODIFIED="1530319651244" TEXT="SFX">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318772362" ID="ID_1062908998" MODIFIED="1530319651244" TEXT="-&#x9;Make a list of every sound you will need in your game&#xa;-&#x9;Record these sounds yourself or get it from the internet and use audacity to edit and make it how you want it to.&#xa;-&#x9;Make sure you have nature sounds, combat sounds etc.&#xa;"/>
</node>
</node>
<node CREATED="1530316119429" FOLDED="true" ID="ID_1407008632" MODIFIED="1530319710604" TEXT="Lighting the Scene">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319223586" ID="ID_48212116" MODIFIED="1530319651244" TEXT="Volumetric Lighting">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319227137" ID="ID_848182845" MODIFIED="1530319651244" TEXT="Light Capacity">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319229553" ID="ID_987172596" MODIFIED="1530319651244" TEXT="Different Colored Lihts">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319233889" ID="ID_870228312" MODIFIED="1530319651244" TEXT="Ambient/Global Illumination">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319241761" ID="ID_1522118111" MODIFIED="1530319651244" TEXT="Baking"/>
</node>
<node CREATED="1530319467417" ID="ID_1813087418" MODIFIED="1530319651244" TEXT="-Volumetric Lighting!!! https://www.youtube.com/watch?v=H5v_X1k02U0&#xa;-Adding light probes throughout Unity.&#xa;-Adding reflection probes throughout the scene which will be enabled and disabled along side the optimisation system.&#xa;-Making soft shadows and baking light maps and get comfortable with the lighting settings, get the most performance + beauty.&#xa;-New unity lighting system&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530317491187" FOLDED="true" ID="ID_1276640631" MODIFIED="1530319752198" TEXT="Animation Development (Blending, Locomotion)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317505315" ID="ID_1708105034" MODIFIED="1530319651244" TEXT="General Player">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317508420" ID="ID_336764957" MODIFIED="1530319651244" TEXT="Player Animations"/>
<node CREATED="1530317512428" ID="ID_272074764" MODIFIED="1530319651244" TEXT="Player Blend Locomotions"/>
</node>
<node CREATED="1530317518371" ID="ID_1558002042" MODIFIED="1530319651244" TEXT="Weapon Animations">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317522683" ID="ID_1022732767" MODIFIED="1530319651244" TEXT="NPC Animations">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317525627" ID="ID_1124262433" MODIFIED="1530319651244" TEXT="Enemy Animatinos">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319717361" ID="ID_580319473" MODIFIED="1530319720364" TEXT="Locomotion System">
<node CREATED="1530319722953" ID="ID_1510033392" MODIFIED="1530319732244" TEXT="-Procedural animations, using the procedural character controller data to modify the animation based on the data. &#xa;-Foot IK "/>
<node CREATED="1530319735745" ID="ID_1626035940" MODIFIED="1530319742916" TEXT="Unity Inbuilt humanoid IK"/>
<node CREATED="1530319743425" ID="ID_1261751761" MODIFIED="1530319744468" TEXT="Or">
<node CREATED="1530319744648" ID="ID_702036486" MODIFIED="1530319746701" TEXT="Buy Final IK"/>
</node>
</node>
</node>
<node CREATED="1530318063747" FOLDED="true" HGAP="24" ID="ID_1161057997" MODIFIED="1530319763492" TEXT="Pre-Requisites " VSHIFT="-5">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="messagebox_warning"/>
<node CREATED="1530318066756" ID="ID_1897317741" MODIFIED="1530319651244" TEXT="Completed Storyboard">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318073291" ID="ID_1700998267" MODIFIED="1530319651244" TEXT="Completed list of Missions">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318079746" ID="ID_732045055" MODIFIED="1530319651244" TEXT="Completed list of forced situations">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318084538" ID="ID_1213931633" MODIFIED="1530319651244" TEXT="Completed list of cinematics">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318089261" ID="ID_394512500" MODIFIED="1530319651244" TEXT="Dialogue list complete">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318100491" ID="ID_1859730171" MODIFIED="1530319651244" TEXT="Where">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318103292" ID="ID_1038697920" MODIFIED="1530319651244" TEXT="Who">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318104787" ID="ID_1554686880" MODIFIED="1530319651244" TEXT="Why">
<font ITALIC="true" NAME="SansSerif" SIZE="12"/>
</node>
</node>
</node>
<node CREATED="1530319797512" FOLDED="true" ID="ID_1217319717" MODIFIED="1530319823988" TEXT="Model todo Humanoids">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319814266" ID="ID_1022496807" MODIFIED="1530319822404" TEXT="-Concept sketching&#xa;-Defining how the player looks verbally + gathering concept photos&#xa;-Tireless modelling + SCULPTING to add detail&#xa;-UV Unwrapping&#xa;-Rigging the character&#xa;-Adding tonnes of shape keys for every aspect&#xa;-Then adding proper IK targets to make it easy for me &#xa;-Weight painting&#xa;-Recording myself in poses of walking etc&#x2026;&#xa;-Animating from live video footage.&#xa;"/>
</node>
</node>
<node CREATED="1530315693798" ID="ID_130867489" MODIFIED="1530319690417" POSITION="left" TEXT="Stage 4 (Polishing)">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530320245592" FOLDED="true" ID="ID_161794268" MODIFIED="1530320264340" TEXT="Post Processing">
<node CREATED="1530320247720" ID="ID_1916251296" MODIFIED="1530320263019" TEXT="-New unity update on post processing volumes for different processing at different positions&#xa;-Creating a custom FOG Shader (w/ multiple colors)&#xa;-Creating image effects in the post processing stack which blend between each other during day night cycles.&#xa;-Adding blood effects and all combat particles.&#xa;-Add walking, sliding and running particles.&#xa;-Add environmental particles such as snow, leaves.&#xa;-Lens flares and sun rays casting down on the earth.&#xa;-Shaders to make the terrain tiling less obvious.&#xa;-Going through the scene and adding decorations where needed and playing the game and seeing what would make this part more interesting etc&#x2026;&#xa;-Eye adaptation tool and create nice eye adaptations.&#xa;-Make sure there are options for post processing to decrease the aliasing filter etc&#x2026;&#xa;-Write your own shaders sometimes to learn the basics.&#xa;-Adding more animations like cloth animations and sword movement etc&#x2026;&#xa;-Dust getting flung up as you walk, snow foot prints.&#xa;"/>
</node>
</node>
<node CREATED="1530315698373" FOLDED="true" HGAP="45" ID="ID_1919228499" MODIFIED="1532108831083" POSITION="right" TEXT="Stage 5 (Optimising)" VSHIFT="-13">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318437706" ID="ID_1173424636" MODIFIED="1530319651243" TEXT="&#xf0a7;Going through and multithreading code where It can be done&#xa;&#xf0a7;Optimising all scripts based on video and implement the C# Job system&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319188234" ID="ID_1390763007" MODIFIED="1530319651243" TEXT="-Go through all the scripts and make sure every script is as highly optimised as possible&#xa;-Adding the C# Job system to most aspects of the scripts&#xa;-Optimise your code&#xa;-Go to the profiler and check what is taking up the most time and then optimize. (This should be done throughout the game)&#x2026;&#xa;-Make sure the scripts that are not being used are constantly disabled, and colliders which are not needed are disabled.&#xa;-Play the game on lower end PC&#x2019;s and Computers to make sure even smaller computers can handle the graphics etc.. by modifying the settings of the game (IN THE GAME).&#xa;-Remove the configuration screen at the start (https://answers.unity.com/questions/134444/is-it-possible.html)&#xa;">
<arrowlink DESTINATION="ID_1390763007" ENDARROW="Default" ENDINCLINATION="0;0;" ID="Arrow_ID_1676906114" STARTARROW="None" STARTINCLINATION="0;0;"/>
<linktarget COLOR="#b0b0b0" DESTINATION="ID_1390763007" ENDARROW="Default" ENDINCLINATION="0;0;" ID="Arrow_ID_1676906114" SOURCE="ID_1390763007" STARTARROW="None" STARTINCLINATION="0;0;"/>
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530315704837" HGAP="23" ID="ID_1038991973" MODIFIED="1530319690417" POSITION="left" TEXT="Stage 6 (UI and Finalising)" VSHIFT="6">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317651651" FOLDED="true" HGAP="46" ID="ID_654285757" MODIFIED="1530320042276" POSITION="right" TEXT="Stage 3 " VSHIFT="2">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317657763" FOLDED="true" ID="ID_871436842" MODIFIED="1530319651243" TEXT="Story / World Integration">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317723395" ID="ID_1963261448" MODIFIED="1530319651243" TEXT="Using the storyboard to construct the gameplay">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317757779" ID="ID_1200035973" MODIFIED="1530319651243" TEXT="Spawning"/>
<node CREATED="1530317759275" ID="ID_1656813564" MODIFIED="1530319651243" TEXT="Dialogue"/>
<node CREATED="1530317764810" ID="ID_1090555784" MODIFIED="1530319651243" TEXT="Cinematic Sequences"/>
</node>
<node CREATED="1530317893860" ID="ID_562235441" MODIFIED="1530319651243" TEXT="Game Manager">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317895963" ID="ID_1180196233" MODIFIED="1530319651243" TEXT="Time Limits"/>
<node CREATED="1530317898620" ID="ID_791248469" MODIFIED="1530319651243" TEXT="Missions">
<node CREATED="1530317902434" ID="ID_1881563282" MODIFIED="1530319651243" TEXT="Mission Assigning"/>
</node>
<node CREATED="1530318023586" ID="ID_1613591946" MODIFIED="1530319651243" TEXT="World Independance">
<node CREATED="1530318026042" ID="ID_1785485821" MODIFIED="1530319651243" TEXT="Time ">
<node CREATED="1530318028170" ID="ID_1722288630" MODIFIED="1530319651243" TEXT="Effects Environment"/>
<node CREATED="1530318031123" ID="ID_852855098" MODIFIED="1530319651243" TEXT="Horde Behaviour"/>
</node>
</node>
</node>
<node CREATED="1530317970755" ID="ID_862732747" MODIFIED="1530319651243" TEXT="Building beautiful cinematic sequences">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317989363" ID="ID_1140582680" MODIFIED="1530319651243" TEXT="Cinematic Camera Styles"/>
<node CREATED="1530317993483" ID="ID_1069758411" MODIFIED="1530319651243" TEXT="PFX"/>
<node CREATED="1530317998834" ID="ID_1089441196" MODIFIED="1530319651243" TEXT="Music"/>
</node>
<node CREATED="1530318014834" ID="ID_557575403" MODIFIED="1530319651243" TEXT="Story Progression w/ NPCS">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318051237" ID="ID_1086670103" MODIFIED="1530319651243" TEXT="Hidden Background Stories">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318058578" ID="ID_1021236783" MODIFIED="1530319651243" TEXT="Forced Situations">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530318063747" ID="ID_1621181527" MODIFIED="1530319651243" TEXT="Pre-Requisites ">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="messagebox_warning"/>
<node CREATED="1530318066756" ID="ID_1360254290" MODIFIED="1530319651243" TEXT="Completed Storyboard">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318073291" ID="ID_5371336" MODIFIED="1530319651243" TEXT="Completed list of Missions">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318079746" ID="ID_1996120381" MODIFIED="1530319651243" TEXT="Completed list of forced situations">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318084538" ID="ID_282931465" MODIFIED="1530319651243" TEXT="Completed list of cinematics">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318089261" ID="ID_272123628" MODIFIED="1530319651243" TEXT="Dialogue list complete">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318100491" ID="ID_1329578803" MODIFIED="1530319651243" TEXT="Where"/>
<node CREATED="1530318103292" ID="ID_1166492413" MODIFIED="1530319651243" TEXT="Who"/>
<node CREATED="1530318104787" ID="ID_1612108183" MODIFIED="1530319651243" TEXT="Why"/>
</node>
</node>
</node>
<node CREATED="1530318288338" FOLDED="true" HGAP="47" ID="ID_444471384" MODIFIED="1531132613537" POSITION="right" TEXT="Current Tasks" VSHIFT="28">
<edge STYLE="bezier"/>
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="idea"/>
<node CREATED="1530318321418" ID="ID_1468356919" MODIFIED="1530319651243" TEXT="Completing Sprint 1">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530318333938" ID="ID_1318655228" MODIFIED="1530326769454" TEXT="Building a full story board">
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="full-3"/>
<node CREATED="1530319152809" ID="ID_42421948" MODIFIED="1530319651243" TEXT="Starting Scene">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319156794" ID="ID_540789977" MODIFIED="1530319651243" TEXT="-Make a sweeping shot over the entire forest and cover all of it&#x2019;s beauty, have birds flying around and castles and show the whole world.&#xa;-Get your name and text on the screen and your company name.&#xa;-Make the screen slowly delve deeper into the forest and the once beautiful forest turn dark and grim and get&#x2019;s darker and darker and you see red eyes and danger lurking in the back and the name &#x2018;NEFARIOUS&#x2019; just fades into view and a eye closing animation is played and an eye opening animation is played and the camera fades to your little mountain where you and your friend live and your story is told.&#xa;-This entire game is like a story being told and the text at the start + the music should be thrilling. Your eyes open and then your friend is waking you up and you get up and put your helmet on. Your friend is panicked and he is trying to wake you up&#x2026;. -&gt; Story.&#xa;-Good post processing and anti aliasing&#xa;-Good music in the background, spine chilling and beautiful!&#xa;"/>
</node>
</node>
<node CREATED="1530318343634" ID="ID_1094844469" MODIFIED="1530326772907" TEXT="Building the map &amp; connecting w/ story">
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="full-4"/>
</node>
<node CREATED="1530318363418" ID="ID_147020471" MODIFIED="1530326774657" TEXT="Make a list of more features">
<font NAME="SansSerif" SIZE="12"/>
<icon BUILTIN="full-5"/>
</node>
<node CREATED="1530320067632" ID="ID_875674828" MODIFIED="1530326776953" TEXT="World Builder">
<icon BUILTIN="full-6"/>
<node CREATED="1530320070833" ID="ID_1274344295" MODIFIED="1530320077796" TEXT="&#xf0a7;Will need a document for this, but a tool that allows for generation of massive open worlds with optimisation built in, such as doors like used in Firewatch, but you can place these and the software patches it up. Cool stuff. So you can build massive world with blend assets, pass in LODS does stitching, auto mesh generation etc&#x2026;&#xa;"/>
<node CREATED="1530326777441" ID="ID_134258559" MODIFIED="1530326778692" TEXT="Plan"/>
</node>
</node>
<node CREATED="1530318937546" ID="ID_1844985791" MODIFIED="1532215411019" POSITION="left" TEXT="Final Stages">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318942385" ID="ID_244170093" MODIFIED="1530319651243" TEXT="Testing">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318984532" ID="ID_340349034" MODIFIED="1530319651243" TEXT="-Send the game out to many people, especially your subscribers &#xa;and make sure at the end of the game there is a feedback and bug reporting section.&#xa;-Especially during the game, they can pause, take a screenshot and send a bug report.&#xa;-They can leave comments and feedback at specific sections.&#xa;">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1532215435430" ID="ID_753432319" MODIFIED="1532215466906" TEXT="This version of the game will be the pre-release vertical slice so they can use ALL the mechanics and fight and a little but of the story will be revealed."/>
</node>
</node>
<node CREATED="1530318944466" ID="ID_54421749" MODIFIED="1530319651243" TEXT="Re-Iteration">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319022470" ID="ID_1186712143" MODIFIED="1530319651243" TEXT="-Take all the feedback and make improvements immediately.&#xa;-Improve the graphics and gameplay based on feedback. If the feedback is lag related make sure you add some optimisation.&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530318948081" FOLDED="true" HGAP="12" ID="ID_1031597189" MODIFIED="1530319651243" TEXT="Post-Production" VSHIFT="45">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319047349" ID="ID_90001429" MODIFIED="1530319651243" TEXT="-You must have a company website&#xa;-Make sure the website links to your blog&#xa;-Make sure the game links to your website&#xa;-The website is like marketing so put your latest game trailer on there, information about the game.&#xa;-Star ratings it has received, parallax scrolling with the epic fights that they are having.&#xa;-Write a thrilling description for the game for steam&#xa;-Game logo&#xa;-Publish on your youtube channel&#xa;-Create an awesome picture to represent the game of your character looking out into the distance with your friend next to you.&#xa;-Go back over the game again, make your final backup and buy an external hard drive just for the game.&#xa;-Be proud&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
</node>
<node CREATED="1530318952169" FOLDED="true" HGAP="43" ID="ID_1308446920" MODIFIED="1530320047460" POSITION="right" TEXT="Marketing" VSHIFT="18">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319082070" ID="ID_1290394926" MODIFIED="1530319651242" TEXT="-Create a trailer using some epic music and using the forest sweep over scene but this tme adding different text and scenes.&#xa;-Trailer example - https://www.youtube.com/watch?v=qdy8S9ttKqo&#xa;-Adding combat scenes and an epic ending scene.&#xa;-&#x2018;A battle of friendship and power&#x2019;&#xa;-&#x2018;A story of betrayal and loyalty&#x2019;&#xa;-Releasing YouTube ads&#xa;-Creating multiple trailers&#xa;-Publishing on facebook&#xa;-Publishing on youtube ads&#xa;-Learn more about this field later&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530319106602" FOLDED="true" ID="ID_981070798" MODIFIED="1530319690417" POSITION="left" TEXT="Steam Ready">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319114778" ID="ID_1395404666" MODIFIED="1530319651242" TEXT="-First the menu will be setup and it will be a very dynamic UI and beautiful. &#xa;-The menu screen will just be some simplistic UI with the main character looking off into the horizon with the forest behind him and the sun hitting him&#xa;-Then when you click play, the UI will disappear and start floating over the forest.&#xa;-The UI has to have the ability to change preferences. &#xa;-Steam overlays will be added + achievements and high scores.&#xa;-I want to setup a forum for the game as well where people can discuss and help each other out because I want to make the game difficult.&#xa;-Steam overlays need to be taken seriously and pausing needs to be a feature that is automatically handled through steams pausing.&#xa;-&#x2018;Esc&#x2019; should also trigger the pause scene.&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530317665232" FOLDED="true" HGAP="15" ID="ID_201603550" MODIFIED="1530320394885" POSITION="left" TEXT="World Development" VSHIFT="-1">
<richcontent TYPE="NOTE"><html>
  <head>
    
  </head>
  <body>
    <p class="MsoListParagraphCxSpFirst" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2"><u><b>Development of model assets</b></u>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpFirst" style="margin-left: 72.0pt; text-indent: -18.0pt">
      
    </p>
    <p class="MsoListParagraphCxSpFirst" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2">a.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">The major assets<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">i.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Terrains (Integrated with terrain system + LODs)<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">ii.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Clouds (A &amp; S) &#8211; Movement integrated + Fading in the distance (shaders).<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">iii.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Lakes (A &amp; S)<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">iv.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Rivers (Animated and shaded)<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2">b.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">Automatic Prefab Generation Tool<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">i.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Drag and drop models for automatic prefab generation + LOD&#8217;s + Auto colliders + Scripts needed and GPU Instancing if required.<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2">c.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">The minor assets <o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">i.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">All world environmental spread assets (trees, rocks, grass) etc.. w/ shape keys on all of them to create a WIDE variety of prebaked land using perlin noise.<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">ii.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Base objects such as tables, tools, etc&#8230; All the items needed for the inventory + crafting system. <o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2">d.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">World Relevance Objects <o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">i.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Houses, Castles, Forts, Defence Systems&#8230;. Based on the story (will be described in the story)&#8230;<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">ii.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Easter eggs objects, things that explain some backstory which make the audience go &#8216;aaaahh&#8217; wow!<o p="#DEFAULT" size="2"></o>&#160;</font>
    </p>
    <p class="MsoListParagraphCxSpMiddle" style="margin-left: 72.0pt; text-indent: -18.0pt">
      <font size="2">e.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">Decorative Objects<o p="#DEFAULT" size="2"></o>&#160; </font>
    </p>
    <p class="MsoListParagraphCxSpLast" style="margin-left: 108.0pt; text-indent: -108.0pt">
      <font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </font><font size="2">i.</font><font face="Times New Roman" size="2">&#160;&#160;&#160;&#160;&#160; </font><font size="2">Such as statues, fountains, temples, shrines, vines, flower gardens.<o p="#DEFAULT" size="2"></o>&#160; </font>
    </p>
  </body>
</html></richcontent>
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317667555" ID="ID_1994395302" MODIFIED="1530319651242" TEXT="Terrains built">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317671411" ID="ID_682459640" MODIFIED="1530319651242" TEXT="Segmented ">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530319282353" ID="ID_1683048844" MODIFIED="1530320387956" TEXT="&#xf0a7;Creating the terrain and setting up terrain LOD systems + world optimisation and map door systems.&#xa;&#xf0a7;Setup pathfinding regions inside the terrain, split based on region and avoid obstacles by auto baking static objects into the nav mesh.&#xa;-Map Design&#xa;&#xf0a7;Design the actual map and make sure it is properly designed to give the user some challenge. &#x2013; Based off concept art and add hidden places, easter eggs, enemy locations camps. Take inspiration from the beautiful concept arts and make it astounding.&#xa;&#xf0a7;Annotate the map to display all the regions, what story segment will occur here and how it will impact the game. How will this region look etc.&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530317674019" ID="ID_915078081" MODIFIED="1530319651241" TEXT="Major Landmarks">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530317689635" ID="ID_1771845686" MODIFIED="1530319651241" TEXT="Story Points">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530317693787" ID="ID_224014169" MODIFIED="1530319651241" TEXT="Key events">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319304953" ID="ID_1341876521" MODIFIED="1530319651241" TEXT="&#xf0a7;&#x9;Creating markers for locations and setting up regions where events occur."/>
</node>
<node CREATED="1530317696035" ID="ID_1519679623" MODIFIED="1530319651241" TEXT="Side Stories">
<font NAME="SansSerif" SIZE="12"/>
</node>
<node CREATED="1530320310097" FOLDED="true" ID="ID_1108243702" MODIFIED="1530320331251" TEXT="Story Integration">
<node CREATED="1530320312664" ID="ID_439330641" MODIFIED="1530320329588" TEXT="-Plan when and where inside the world different aspects of the cut scenes are going to occur.&#xa;-Plan where the different spawning locations are where the game will end and how it will end.&#xa;-Then plan where the minor aspects of the story are and dialogues and references needed for that.&#xa;-Story progression system&#xa;-Making sure that time is working appropriately throughout the game and horde movement is affecting your dialogue and the cinematics.&#xa;-Different bosses throughout the game.&#xa;-Write all the dialogue and appropriate NPC&#x2019;s communication&#xa;-Every way that the player takes should bring a subset of challenges.&#xa;-Create event systems to every region (optimised using some collider) and add dialogue options, dialogue from your friend, NPC showing up.&#xa;-Create the cut scenes at all of the cut scene locations, and make sure they are beautiful and smooth.&#xa;-Every event can be triggered only once, the trigger may change based on the story stage. This is to prevent looping.&#xa;-Make sure there is no event overlapping each other and they are queued up.&#xa;-Re-test and make sure all of the events are working as they are supposed to.&#xa;-Add mission directives at locations and hints of what to do if the player looks lost or he is going in the wrong direction etc&#x2026;&#xa;-Give them missions at major story points.&#xa;-Setup achievement points (for future integration with Steam)&#xa;"/>
</node>
</node>
<node CREATED="1530317707707" FOLDED="true" ID="ID_608516048" MODIFIED="1530320357235" TEXT="Development of the map">
<font BOLD="true" NAME="SansSerif" SIZE="12"/>
<node CREATED="1530319257577" ID="ID_1095217367" MODIFIED="1530319651241" TEXT="-Map Design&#xa;&#xf0a7;Design the actual map and make sure it is properly designed to give the user some challenge. &#x2013; Based off concept art and add hidden places, easter eggs, enemy locations camps. Take inspiration from the beautiful concept arts and make it astounding.&#xa;&#xf0a7;Annotate the map to display all the regions, what story segment will occur here and how it will impact the game. How will this region look etc.&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
<node CREATED="1530318590746" FOLDED="true" ID="ID_266560423" MODIFIED="1530320358700" TEXT="Advanced World System">
<font NAME="SansSerif" SIZE="12"/>
<node CREATED="1530318597237" ID="ID_1900348183" MODIFIED="1530319651241" TEXT="&#xf0a7;Auto segmenting and LOD tool (Sebastian Lague)&#xa;&#xf0a7;Placement of objects in scene&#xa;&#xf0a7;Create a perlin editor where the texture is created and a seed can be changed and modified until a desired result is given then a perlin reader script can be made to read it.&#xa;&#xf0a7;Painting objects onto scene&#xa;&#xf0a7;Photogrammetry process..&#xa;">
<font NAME="SansSerif" SIZE="12"/>
</node>
</node>
</node>
<node CREATED="1530319984664" FOLDED="true" HGAP="47" ID="ID_1316223867" MODIFIED="1532401486682" POSITION="right" TEXT="Order" VSHIFT="12">
<node CREATED="1530319988792" ID="ID_523707607" MODIFIED="1530320014044" TEXT="1.Writing all the systems + story / scripts in the game (ex. locomotion, ai, movement) &#x2013; 4 months&#xa;2.Designing the world (World, Player, Enemies, Shaders, Materials, UV Maps, Normal Maps) &#x2013; 3 Months&#xa;3.Animating and Stitching together with the scripts &#x2013; 1-2 months&#xa;4.World Design (Placing and positioning everything and building the entire world from a map) setting up pathfinding, marking out locations where events occur, setting up the optimisation of the world, setting up perlin noise and world generation, setting up horde movement throughout the world + proper interactions &#x2026; &#x2013; 1 month&#xa;5.Lighting and Graphical Effects &#x2013; encompass light probes, reflection probes, GPU Instancing&#xa;6.Adding the story and cut scenes to the end result (all event systems all dialogue systems) implementing the story and adding gameplay cores such as missions and directives. So basically the game is constructed in this phase. Until before all the game was just gathering bones now we will throw it together. &#x2013; 1-3 (Communication and dialogue systems) months&#xa;7.Making the game work from start to finish (Event Systems and Spawning Mnagement) &#x2013; 2 months&#xa;8.Post Processing and Particle Effects + Touch-ups &#x2013; 2 weeks&#xa;9.Making the starting scene/ending scene and setup of the game scene. Beginning title screens.&#xa;10.Optimising the entire game &#x2013; 1 month&#xa;11.Music and SFX implementation (player&#x2019;s walking, sound effects make sure they&#x2019;re not choppy and they have blended together) &#x2026; Don&#x2019;t over crowd the sound system, decrease insignificant sounds etc.&#x2026; &#x2013; 1 month&#xa;12.UI Menus and Steam Overlays + Steam Achievements etc.. &#x2013; 1 month&#xa;13.Finalising + Releasing Blog &#x2013; 2 months&#xa;14.Testing phase (Friends, Family) &#x2013; 2 weeks&#xa;15.Post Production &#x2013; 1 month&#xa;16.Advertising and making it known + Trailers&#xa;17.Publishing &#x2013; 1 month&#xa;"/>
</node>
<node CREATED="1530614985408" ID="ID_22457388" MODIFIED="1532108954290" POSITION="right" TEXT="Pre-Developemtn">
<node CREATED="1530614988045" ID="ID_1549373052" MODIFIED="1530614990412" TEXT="Story">
<node CREATED="1530614991593" ID="ID_398632733" MODIFIED="1530614993061" TEXT="Story Board">
<node CREATED="1530615022249" ID="ID_128764150" MODIFIED="1530615027941" TEXT="Every Possible Event Drawn Out"/>
</node>
<node CREATED="1530614993544" ID="ID_1963913252" MODIFIED="1530614996084" TEXT="Character Map">
<node CREATED="1530615013130" ID="ID_931688968" MODIFIED="1530615016949" TEXT="Background Stories"/>
<node CREATED="1530615017410" ID="ID_854797628" MODIFIED="1530615020724" TEXT="Contribution to Gameplay"/>
</node>
</node>
<node CREATED="1530614996803" ID="ID_177578733" MODIFIED="1532129467509" TEXT="Map Development">
<icon BUILTIN="yes"/>
<node CREATED="1530614999648" ID="ID_1660886938" MODIFIED="1530615002173" TEXT="Leveling Off"/>
<node CREATED="1530615002683" ID="ID_1436444624" MODIFIED="1530615005437" TEXT="Story Points"/>
<node CREATED="1530615005946" ID="ID_1332394701" MODIFIED="1530615011812" TEXT="Names/Character Introductions"/>
</node>
</node>
</node>
</map>
